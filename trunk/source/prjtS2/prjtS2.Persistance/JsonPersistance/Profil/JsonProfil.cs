using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.Compte;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace prjtS2.Persistance.JsonPersistance.Profil
{
    /// <summary>
    /// Json GEstion of Profil, For Docs refer to IGestion
    /// </summary>
    public class JsonProfil // : JsonGestion<FunctLibrary.Compte.Profil>
    {
        public JsonProfil()
        {
            GetListAllFromFile();
        }

        public string eltName => "profil";

        public List<string> Lib => Library.COMPTES;

        public string FileName => "data/json/" + this.GetType().Name + ".json";

        public JObject Pattern(FunctLibrary.Compte.Profil elt)
        {
            bool admin = false;
            if(Library.ADMIN_PROFIL.Contains(elt.Username)) { admin = true; }

            return new JObject(
                new JProperty(eltName,
                    new JObject(
                        new JProperty("username", elt.Username),
                        new JProperty("nom", elt.Nom),
                        new JProperty("prenom", elt.Prenom),
                        new JProperty("biographie", elt.Biographie),
                        new JProperty("mail", elt.Mail),
                        new JProperty("mdp", elt.Password),
                        new JProperty("dateN", elt.DateNaissance.ToString("yyyyMMdd")),
                        new JProperty("loc", elt.Localisation.Key),
                        new JProperty("allergies",
                            new JObject(
                                new JProperty("alcool", elt.HasAlcool),
                                new JProperty("gluten", elt.HasGluten),
                                new JProperty("levure", elt.HasLevure)
                                )
                            ),
                        new JProperty("favoris",
                                new JArray(elt.Favoris.Select(i => i.Nom.ToLower()))
                        ),
                        new JProperty("pdp", elt.Image),
                        new JProperty("isAdmin", admin)
                        )
                    )
                );
        }

        /*
        public void AddAllToFile()
        {
            var allElts = Lib.Select(elt => Pattern(elt));
            var EltFile = new JObject(new JProperty("root", allElts));
            Console.WriteLine(EltFile);
            SaveAllData(EltFile);
        }
        */

        public void AddOneToFile(FunctLibrary.Compte.Profil NewEntity)
        {
            var jsonVal = LoadFile();
            Console.WriteLine(jsonVal);
            jsonVal["root"][0].AddBeforeSelf(Pattern(NewEntity));
            SaveAllData(jsonVal);
        }

        public void GetDicoAllFromFile(Dictionary<string, FunctLibrary.Compte.Profil> Lib)
        {
            var jsonVal = LoadFile();
            Lib.Clear();

            foreach(var item in jsonVal["root"])
            {
                if((bool)item[eltName]["isAdmin"]) { Library.ADMIN_PROFIL.Add(item[eltName]["username"].ToString()); }

                var p = new FunctLibrary.Compte.Profil(
                        item[eltName]["username"].ToString(),
                        item[eltName]["nom"].ToString(),
                        item[eltName]["prenom"].ToString(),
                        item[eltName]["mdp"].ToString(),
                        item[eltName]["mail"].ToString(),
                        DateTime.ParseExact(item[eltName]["dateN"].ToString(), "yyyyMMdd",null),
                        new FunctLibrary.Ressources.Localisation( item[eltName]["loc"].ToString()),
                        item[eltName]["biographie"].ToString(),
                        item[eltName]["pdp"].ToString()
                        );
                if( (bool)item[eltName]["allergies"]["alcool"]) { p.imperatifs.Add(FunctLibrary.Ressources.Allergene.ALCOOL); }
                if( (bool)item[eltName]["allergies"]["gluten"]) { p.imperatifs.Add(FunctLibrary.Ressources.Allergene.GLUTEN); }
                if( (bool)item[eltName]["allergies"]["levure"]) { p.imperatifs.Add(FunctLibrary.Ressources.Allergene.LEVURE); }

                foreach(string f in item[eltName]["favoris"].ToArray()) { p.Favoris.Add(Library.DICO_BIERES[f]); }
            }
        }

        public void GetListAllFromFile()
        {
            var jsonVal = LoadFile();
            Lib.Clear();

            foreach (var item in jsonVal["root"])
            {
                if ((bool)item[eltName]["isAdmin"]) { Library.ADMIN_PROFIL.Add(item[eltName]["username"].ToString()); }

                Lib.Add(item[eltName]["username"].ToString());
            }
        }

        public void RemoveOneFromFile(string entity)
        {
            var jsonVal = LoadFile();

            IEnumerable<JToken> toDelete = jsonVal["root"].Where(x => (string)x[eltName]["username"].ToString() == entity);
            toDelete.First().Remove();

            SaveAllData(jsonVal);
        }

        public void UpdateOneFromFile(string OldEntity, FunctLibrary.Compte.Profil NewEntity)
        {
            RemoveOneFromFile(OldEntity);
            AddOneToFile(NewEntity);
        }

        public FunctLibrary.Compte.Profil GetOneFromFile(string entity)
        {
            var jsonVal = LoadFile();

            IEnumerable<JToken> items = jsonVal["root"].Where(x => (string)x[eltName]["username"].ToString() == entity);
            JToken item = items.First();
            
            if(item is null || item["profil"]["username"] is null || item["profil"]["username"].ToString() == "" ) { throw new Exception("This UserName doesn't represent anything!"); }

            if ((bool)item[eltName]["isAdmin"]) { Library.ADMIN_PROFIL.Add(item[eltName]["username"].ToString()); }

            var p = new FunctLibrary.Compte.Profil(
                    item[eltName]["username"].ToString(),
                    item[eltName]["nom"].ToString(),
                    item[eltName]["prenom"].ToString(),
                    item[eltName]["mdp"].ToString(),
                    item[eltName]["mail"].ToString(),
                    DateTime.ParseExact(item[eltName]["dateN"].ToString(), "yyyyMMdd", null),
                    new FunctLibrary.Ressources.Localisation(item[eltName]["loc"].ToString()),
                    item[eltName]["biographie"].ToString(),
                    item[eltName]["pdp"].ToString()
                    );
            if ((bool)item[eltName]["allergies"]["alcool"]) { p.imperatifs.Add(FunctLibrary.Ressources.Allergene.ALCOOL); }
            if ((bool)item[eltName]["allergies"]["gluten"]) { p.imperatifs.Add(FunctLibrary.Ressources.Allergene.GLUTEN); }
            if ((bool)item[eltName]["allergies"]["levure"]) { p.imperatifs.Add(FunctLibrary.Ressources.Allergene.LEVURE); }

            foreach (string f in item[eltName]["favoris"].ToArray()) { p.Favoris.Add(Library.DICO_BIERES[f]); }

            return p;
        }

        public JObject LoadFile()
        {
            string jsonTxt = File.ReadAllText(FileName);
            return JObject.Parse(jsonTxt);
        }

        public void SaveAllData(JObject document)
        {
            File.WriteAllText(FileName, document.ToString());
        }

        public bool UsernameTaken(string username)
        {
            var jsonVal = LoadFile();

            JToken item = jsonVal["root"].First(x => (string)x[eltName]["username"].ToString() == username);
            return (item["username"] is null || item["username"].ToString() == "");
        }
    }
}
