using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Ressources
{
    /// <summary>
    /// Specificities of the beer
    /// </summary>
    public class Specificite : RessourceAccess
    {
        public Specificite(string k) : base(k)
        {
        }

        public Specificite(string k, string val) : base(k, val)
        {
        }

        public override Dictionary<string, string> Lib => Ressource.Parameter.DICO_SPEC;
    }
}
