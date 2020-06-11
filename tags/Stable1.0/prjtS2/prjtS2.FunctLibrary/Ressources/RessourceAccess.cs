using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace prjtS2.FunctLibrary.Ressources
{
    /// <summary>
    /// Class used to Create any Ressource / Parameter, Implement IRessourceAccessable
    /// </summary>
    public abstract class RessourceAccess : IRessourceAccessable
    {
        /// <summary>
        /// Dictionary collecting Key/Value allowed
        /// </summary>
        public abstract Dictionary<string, string> Lib { get; }

        /// <summary>
        /// Constructor to instantiate from the Dictionary 
        /// </summary>
        /// <param name="k">Key in the dictionary</param>
        public RessourceAccess(string k)
        {
            if (CheckExist(k.ToLower()))
            {
                Key = k.ToLower();
            }
            else
            {
                throw new Exception("This Key Doesn't exist in the DICTIONNARY: " + GetType());
            }
        }

        /// <summary>
        /// Constructor used to instantiate a new Ressource Access in the Lib
        /// </summary>
        /// <param name="k">Key of new Ressource</param>
        /// <param name="val">Value of the new Ressource</param>
        public RessourceAccess(string k, string val)
        {
            if (val is null || val == "") { throw new Exception("The value can't be null"); }

            if (!CheckExist(k.ToLower()))
            {
                Lib.Add(k.ToLower(), val);
                this.Key = k.ToLower();
            }
            else
            {
                throw new Exception("La clé que vous tentez d'utiliser existe déjà");
            }

            
        }

        /// <summary>
        /// Keep the Key of the Dictionnary for a quick access for comparaison and listing
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Keep the Value of the dictionnary for a quick access for a print
        /// </summary>
        public string Value => Lib[Key];


        /// <summary>
        /// Check if the key exist and if it's in this precise Dictionary
        /// </summary>
        /// <param name="k">The key we want to test</param>
        /// <returns>Does it exist or not</returns>
        public bool CheckExist(string k)
        {
            if (k is null  || k == "" ) { throw new Exception("The key can't be null"); }

            return Lib.ContainsKey(k.ToLower());
        }


        /// <summary>
        /// To string returns the Value
        /// </summary>
        /// <returns>Value</returns>
        public override string ToString()
        {
            return Value;
        }

    }
}
