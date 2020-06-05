using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Ressources
{
    /// <summary>
    /// Type of the beer
    /// </summary>
    public class TypeBiere : RessourceAccess , IRessourceAccessable
    {
        public TypeBiere(string k) : base(k)
        {
        }

        public TypeBiere(string k, string val) : base(k, val)
        {
        }

        public override Dictionary<string, string> Lib => Ressource.Parameter.DICO_TYPE;
    }
}
