using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Ressources
{
    /// <summary>
    /// Taste of the beer
    /// </summary>
    public class Arome : RessourceAccess
    {
        public Arome(string k) : base(k)
        {
        }

        public Arome(string k, string val) : base(k, val)
        {
        }

        public override Dictionary<string, string> Lib => Ressource.Parameter.DICO_AROMES;
    }
}
