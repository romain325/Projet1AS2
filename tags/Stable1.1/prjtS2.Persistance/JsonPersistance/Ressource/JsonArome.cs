using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.Text;
using static prjtS2.FunctLibrary.Ressources.Ressource;

namespace prjtS2.Persistance.JsonPersistance.Ressource
{
    /// <summary>
    /// Json GEstion of Arome, For Docs refer to IGestion
    /// </summary>
    public class JsonArome : JsonGestionRessourceAccess<Arome>
    {
        public override Dictionary<string, string> Lib => Parameter.DICO_AROMES;

        public override string eltName => "arome";
    }
}
