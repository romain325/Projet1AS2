using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Ressources
{
    /// <summary>
    /// Looking aspect of the beer
    /// </summary>
    public class Style : RessourceAccess
    {
        public Style(string k) : base(k)
        {
        }

        public Style(string k, string val) : base(k, val)
        {
        }

        public override Dictionary<string, string> Lib => Ressource.Parameter.DICO_STYLE;

    }
}
