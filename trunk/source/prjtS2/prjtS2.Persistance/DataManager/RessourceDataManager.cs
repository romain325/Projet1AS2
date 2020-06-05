using prjtS2.Persistance.JsonPersistance.Ressource;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.Persistance
{
    /// <summary>
    /// Ressource Data Manager
    /// </summary>
    public class RessourceDataManager
    {
        public JsonLocalisation LocData { get; } = new JsonLocalisation();
        public JsonArome AromeData { get; } = new JsonArome();
        public JsonSpec SpecData { get; } = new JsonSpec();
        public JsonStyle StyleData { get; } = new JsonStyle();
        public JsonType TypeBData { get; } = new JsonType();
        public JsonCereale CerealeData { get; } = new JsonCereale();
        public JsonCouleur CouleurData { get; } = new JsonCouleur();
    }
}
