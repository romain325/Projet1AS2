using Newtonsoft.Json.Linq;
using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace prjtS2.Persistance.JsonPersistance.Ressource
{
    /// <summary>
    /// Json GEstion of RessourceAccess, For Docs refer to IGestion
    /// </summary>
    /// <typeparam name="T">Derived class of RessourceAccess</typeparam>
    public abstract class JsonGestionRessourceAccess<T> : JsonGestion<T> where T : RessourceAccess
    {
        public abstract Dictionary<string, string> Lib { get; }
        public abstract string eltName { get; }

        public override void AddAllToFile()
        {
            var allElts = Lib.Select(elt =>
                new JObject(
                    new JProperty(eltName,
                        new JObject(
                            new JProperty("key", elt.Key),
                            new JProperty("value", elt.Value)
                            )
                    )));

            var EltFile = new JObject(new JProperty("root", allElts));

            SaveAllData(EltFile);
        }

        public override void AddOneToFile(T NewEntity)
        {
            var jsonVal = LoadFile();

            jsonVal["root"][0].AddBeforeSelf(new JObject(
                    new JProperty(eltName,
                        new JObject(
                            new JProperty("key", NewEntity.Key),
                            new JProperty("value", NewEntity.Value)
                            )
                    )));

            SaveAllData(jsonVal);
        }

        public override void GetDicoAllFromFile()
        {
            var jsonVal = LoadFile();

            Lib.Clear();

            foreach(var item in jsonVal["root"])
            {
                Lib.Add((string)item[eltName]["key"].ToString().ToLower(), (string)item[eltName]["value"]);
            }
        }

        public override void RemoveOneFromFile(string entity)
        {
            var jsonFile = LoadFile();

            IEnumerable<JToken> toDelete = jsonFile["root"].Where(x => (string)x[eltName]["key"] == entity );
            toDelete.First().Remove();

            SaveAllData(jsonFile);
        }

        public override void UpdateOneFromFile(string OldEntity, T NewEntity)
        {
            var jsonFile = LoadFile();

            IEnumerable<JToken> toUpdate = jsonFile["root"].Where(x => (string)x[eltName]["key"] == OldEntity);

            
            JToken modifyVal = toUpdate.First();
            modifyVal[eltName]["key"] = NewEntity.Key;
            modifyVal[eltName]["value"] = NewEntity.Value;

            Console.WriteLine(modifyVal.ToString());

            SaveAllData(jsonFile);
        }
    }
}
