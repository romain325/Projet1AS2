using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace prjtS2.FunctLibrary.Ressources
{
    /// <summary>
    /// Cereales Contained in the beer
    /// </summary>
    public class Cereale : RessourceAccess
    {
        public Cereale(string k) : base(k)
        {
        }

        public Cereale(string k, string val) : base(k, val)
        {
        }


        public override Dictionary<string, string> Lib => Ressource.Parameter.DICO_CEREALES;
    }
}
