using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using prjtS2.FunctLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjtS2.Persistance.JsonPersistance.Produit
{
    /// <summary>
    /// Json GEstion of Brasserie, For Docs refer to IGestion
    /// </summary>
    public class JsonBrasserie : JsonProduit<FunctLibrary.Produit.Brasserie>
    {
        public override Dictionary<string, FunctLibrary.Produit.Brasserie> Lib => Library.DICO_BRASSERIES;

        public override string eltName => "brasserie";

        public override JObject Pattern(FunctLibrary.Produit.Brasserie elt) { return (new JObject(
                    new JProperty(eltName,
                        new JObject(
                            new JProperty("name", elt.Nom),
                            new JProperty("desc", elt.Description),
                            new JProperty("nbNote", elt.NbNotes),
                            new JProperty("noteTotal", elt.NoteTotal),
                            new JProperty("loc", elt.Loc.Key),
                            new JProperty("image",
                                new JArray(elt.Images.Select(i => i)
                                )
                            )))
                            ));
        }


        public override void GetDicoAllFromFile()
        {
            var jsonVal = LoadFile();

            Lib.Clear();

            foreach (var item in jsonVal["root"])
            {
                
                    new FunctLibrary.Produit.Brasserie((string)item[eltName]["name"].ToString(),
                                    (string)item[eltName]["desc"].ToString(),
                                    new FunctLibrary.Ressources.Localisation((string)item[eltName]["loc"].ToString()),
                                    item[eltName]["image"][0].ToString(),
                                    item[eltName]["image"][1].ToString(),
                                    item[eltName]["image"][2].ToString(),
                                    (int)item[eltName]["nbNote"],
                                    (long)item[eltName]["noteTotal"]
                        
                    );
            }
        }

    }
}
