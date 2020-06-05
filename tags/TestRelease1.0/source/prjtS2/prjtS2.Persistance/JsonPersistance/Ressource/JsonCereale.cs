using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.Text;
using static prjtS2.FunctLibrary.Ressources.Ressource;

namespace prjtS2.Persistance.JsonPersistance.Ressource
{
    /// <summary>
    /// Json GEstion of Cereals, For Docs refer to IGestion
    /// </summary>
    public class JsonCereale : JsonGestionRessourceAccess<Cereale>
    {
        public override Dictionary<string, string> Lib => Parameter.DICO_CEREALES;

        public override string eltName => "cereale";
    }
}
