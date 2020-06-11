using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjtS2.Persistance.JsonPersistance.Produit
{
    /// <summary>
    /// Json GEstion of a Product, For Docs refer to IGestion
    /// </summary>
    public abstract class JsonProduit<T> : JsonGestion<T> where T : FunctLibrary.Produit.Produit
    {
        public abstract Dictionary<string, T> Lib { get; }
        public abstract string eltName { get; }
        public abstract JObject Pattern(T elt);

        public override void AddAllToFile()
        {
            var allElts = Lib.Select(elt => Pattern(elt.Value));
            var EltFile = new JObject(new JProperty("root", allElts));
            SaveAllData(EltFile);
        }

        public override void AddOneToFile(T NewEntity)
        {
            var jsonVal = LoadFile();
            if (jsonVal["root"].Count() == 0)
            {
                AddAllToFile();
            }
            else
            {
                jsonVal["root"][0].AddBeforeSelf(Pattern(NewEntity));
            }

            

            SaveAllData(jsonVal);
        }


        public override void RemoveOneFromFile(string entity)
        {
            var jsonVal = LoadFile();

            IEnumerable<JToken> toDelete = jsonVal["root"].Where(x => (string)x[eltName]["name"].ToString().ToLower() == entity.ToLower());
            toDelete.First().Remove();

            SaveAllData(jsonVal);
        }

        public override void UpdateOneFromFile(string OldEntity, T NewEntity)
        {
            RemoveOneFromFile(OldEntity);
            AddOneToFile(NewEntity);
        }
    }
}
