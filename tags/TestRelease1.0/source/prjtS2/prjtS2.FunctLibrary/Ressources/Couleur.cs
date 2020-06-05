using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Ressources
{
    /// <summary>
    /// Color of the beer
    /// </summary>
    public class Couleur : RessourceAccess
    {
        public Couleur(string k) : base(k)
        {
        }

        public Couleur(string k, string val) : base(k, val)
        {
        }

        public override Dictionary<string, string> Lib => Ressource.Parameter.DICO_COULEURS;
    }
}
