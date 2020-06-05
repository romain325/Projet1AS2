using prjtS2.Persistance.JsonPersistance.Produit;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.Persistance
{
    /// <summary>
    /// Product Data Manager
    /// </summary>
    public class ProduitDataManager
    {
        public JsonBrasserie BreweryData { get; } = new JsonBrasserie();
        public JsonBiere BeerData { get; } = new JsonBiere();
        public JsonPropBiere PropBeerData { get; } = new JsonPropBiere();
        public JsonPropBrew PropBrewData { get; } = new JsonPropBrew();
    }
}
