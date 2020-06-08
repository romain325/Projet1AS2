using Newtonsoft.Json.Linq;
using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.Produit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjtS2.Persistance.JsonPersistance.Produit
{
    /// <summary>
    /// Json GEstion of Brewery Proposition, For Docs refer to IGestion
    /// </summary>
    public class JsonPropBrew : JsonProduit<PropBrasserie>
    {
        public override Dictionary<string, PropBrasserie> Lib => Library.PROP_BRASSERIES;
        
        public override string eltName => "brasserie";

        public override void GetDicoAllFromFile()
        {
            var jsonVal = LoadFile();

            Lib.Clear();

            foreach (var item in jsonVal["root"])
            {

                new FunctLibrary.Produit.PropBrasserie((string)item[eltName]["name"].ToString(),
                                (string)item[eltName]["desc"].ToString(),
                                new FunctLibrary.Ressources.Localisation((string)item[eltName]["loc"].ToString()),
                                item[eltName]["image"][0].ToString(),
                                item[eltName]["image"][1].ToString(),
                                item[eltName]["image"][2].ToString(),
                                null

                );
            }
        }

        public override JObject Pattern(PropBrasserie elt)
        {
            return (new JObject(
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
        
    }
}
