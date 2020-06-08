using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace prjtS2.Persistance.JsonPersistance
{
    /// <summary>
    /// Json Method of the IGestion Interface
    /// </summary>
    /// <typeparam name="T">Class to save in JSON</typeparam>
    public interface IJsonGestion<T> : IGestion<T, JObject> where T : class
    {
    }
}
