using Newtonsoft.Json.Linq;
using prjtS2.FunctLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace prjtS2.Persistance.JsonPersistance
{
    /// <summary>
    /// Json Gestion of data, For Docs refer to IGestion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class JsonGestion<T> : IJsonGestion<T> where T : class
    {
        public JsonGestion()
        {
            this.GetDicoAllFromFile();

        }

        public string FileName => "data/json/" + this.GetType().Name + ".json";

        public abstract void AddAllToFile();

        public abstract void AddOneToFile(T NewEntity);

        public abstract void GetDicoAllFromFile();

        public JObject LoadFile()
        {
            string jsonTxt = File.ReadAllText(FileName);
            return JObject.Parse(jsonTxt);
        }

        public abstract void RemoveOneFromFile(string entity);

        public void SaveAllData(JObject document)
        {
            File.WriteAllText(FileName, document.ToString());
        }

        public abstract void UpdateOneFromFile(string OldEntity, T NewEntity);
    }
}
