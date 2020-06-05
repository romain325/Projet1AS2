using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.Produit;
using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace prjtS2.Persistance.JsonPersistance.Produit
{
    /// <summary>
    /// Json GEstion of Beer, For Docs refer to IGestion
    /// </summary>
    public class JsonBiere : JsonProduit<Biere>
    {
        public override Dictionary<string, Biere> Lib => Library.DICO_BIERES;

        public override string eltName => "biere";

        public override void GetDicoAllFromFile()
        {
            var jsonFile = LoadFile();

            Lib.Clear();

            foreach(var item in jsonFile["root"])
            {
                var styles = new List<Style>();
                foreach (string i in item[eltName]["apparence"]["styles"].ToArray()) { styles.Add(new Style(i)); }
                var cereales = new List<Cereale>();
                foreach (string i in item[eltName]["gout"]["cereales"].ToArray()) { cereales.Add(new Cereale(i)); }
                var types = new List<TypeBiere>();
                foreach (string i in item[eltName]["gout"]["types"].ToArray()) { types.Add(new TypeBiere(i)); }
                var specs = new List<Specificite>();
                foreach (string i in item[eltName]["gout"]["spec"].ToArray()) { specs.Add(new Specificite(i)); }
                var aromes = new List<Arome>();
                foreach (string i in item[eltName]["gout"]["aromes"].ToArray()) { aromes.Add(new Arome(i)); }

                new Biere(item[eltName]["name"].ToString(),
                            item[eltName]["desc"].ToString(),
                            (float)item[eltName]["degree"],
                            (float)item[eltName]["prix"],
                            item[eltName]["brasserie"].ToString(),
                            new FunctLibrary.DetailBiere.Apparence(
                                new FunctLibrary.Ressources.Couleur(item[eltName]["apparence"]["couleur"].ToString()),
                                styles
                                ),
                            new FunctLibrary.DetailBiere.Gout(
                                cereales,
                                types,
                                specs,
                                aromes
                                ),
                            item[eltName]["image"][0].ToString(),
                            item[eltName]["image"][1].ToString(),
                            item[eltName]["image"][2].ToString(),
                            (bool)item[eltName]["allergenes"]["alcool"],
                            (bool)item[eltName]["allergenes"]["levure"],
                            (bool)item[eltName]["allergenes"]["gluten"],
                            (int)item[eltName]["nbNote"],
                            (long)item[eltName]["noteTotal"]

                    );
            }
        }

        public override JObject Pattern(Biere elt)
        {
            return new JObject(
                new JProperty(eltName,
                    new JObject(
                        new JProperty("name", elt.Nom),
                        new JProperty("desc", elt.Description),
                        new JProperty("nbNote", elt.NbNotes),
                        new JProperty("noteTotal", elt.NoteTotal),
                        new JProperty("degree", elt.Degrees),
                        new JProperty("prix", elt.PrixMoyen),
                        new JProperty("brasserie",elt.Brasserie.Nom.ToLower()),
                        new JProperty("allergenes",
                            new JObject(
                                new JProperty("alcool", elt.HasAlcool),
                                new JProperty("gluten", elt.HasGluten),
                                new JProperty("levure", elt.HasLevure)
                                )
                            ),

                        new JProperty("apparence",
                            new JObject(
                                new JProperty("couleur", elt.Apparence.couleur.Key),
                                new JProperty("styles",
                                    new JArray(elt.Apparence.Styles.Select(i => i.Key))
                                    )
                                )
                            ),
    
                        new JProperty("gout",
                            new JObject(
                                new JProperty("cereales",
                                    new JArray(elt.Gout.Cereales.Select(i => i.Key))
                                    ),
                                new JProperty("types",
                                    new JArray(elt.Gout.Types.Select(i => i.Key))
                                    ),
                                new JProperty("spec",
                                    new JArray(elt.Gout.Specificites.Select(i => i.Key))
                                    ),
                                new JProperty("aromes",
                                    new JArray(elt.Gout.Aromes.Select(i => i.Key))
                                    )
                                )
                            ),
                        new JProperty("image",
                            new JArray(elt.Images.Select(i => i))
                        )
                    )
                )
                );
        }
    }
}
