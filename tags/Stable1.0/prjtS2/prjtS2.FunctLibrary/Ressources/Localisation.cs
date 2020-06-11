using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace prjtS2.FunctLibrary.Ressources
{
    /// <summary>
    /// All the countries around the world
    /// </summary>
    public class Localisation : RessourceAccess
    {
        public Localisation(string k) : base(k)
        {
        }

        public Localisation(string k, string val) : base(k, val)
        {
        }

        public override Dictionary<string, string> Lib => Ressource.Parameter.CountryArrays;

    }
}
