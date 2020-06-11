using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Ressources
{
    /// <summary>
    /// Interface allowing a Ressource to be accessible
    /// </summary>
    public interface IRessourceAccessable
    {
        /// <summary>
        /// Lib where key and value can be found
        /// </summary>
        public Dictionary<string, string> Lib { get; }

        /// <summary>
        /// Key of the Instance
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Value of the Instance
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Check if the Key Already Exists
        /// </summary>
        /// <param name="key">key to test</param>
        /// <returns>if the key exist or not </returns>
        public bool CheckExist(string key);


    }
}
