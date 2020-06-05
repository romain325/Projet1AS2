using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.Text;
using static prjtS2.FunctLibrary.Ressources.Ressource;

namespace prjtS2.Persistance.JsonPersistance.Ressource
{
    /// <summary>
    /// Json GEstion of Localisation, For Docs refer to IGestion
    /// </summary>
    public class JsonLocalisation : JsonGestionRessourceAccess<Localisation>
    {
        public override Dictionary<string, string> Lib => Parameter.CountryArrays;

        public override string eltName => "country";
    }
}
