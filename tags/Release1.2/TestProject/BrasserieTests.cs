using Microsoft.VisualStudio.TestTools.UnitTesting;
using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.DetailBiere;
using prjtS2.FunctLibrary.Produit;
using prjtS2.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Tests
{
    /// <summary>
    /// Test Class Dedicated to the MainBrewery Function Test
    /// </summary>
    [TestClass()]
    public class BrasserieTests
    {
        readonly DbDataManager db = new DbDataManager();

        /// <summary>
        /// Constructor test --> Properly and Error Management
        /// </summary>
        [TestMethod()]
        public void BrasserieTest()
        {

            try
            {
                var br = new Brasserie("nom", "desc", null, "data/logo.png", "data/logo.png", "data/logo.png");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is Exception);
                Assert.IsFalse(Library.DICO_BRASSERIES.ContainsKey("nom"));
            }

            var b = new Brasserie("nom","desc",new Ressources.Localisation("fr"),"data/logo.png", "data/logo.png", "data/logo.png");
            Assert.IsTrue(Library.DICO_BRASSERIES.ContainsKey("nom"));


        }


        /// <summary>
        /// Add A New Beer Function Test
        /// </summary>
        [TestMethod()]
        public void AddNewBeerTest()
        {
            Apparence apparence = new Apparence(new Ressources.Couleur("rouge"), new List<Ressources.Style>());
            Gout gout = new Gout(new List<Ressources.Cereale>(), new List<Ressources.TypeBiere>(), new List<Ressources.Specificite>(), new List<Ressources.Arome>());
            Brasserie b = new Brasserie("nom", "desc", new Ressources.Localisation("fr"), "data/logo.png", "data/logo.png", "data/logo.png");
            Biere p = new Biere("del", "desc", 0, 0, "nom", apparence, gout, "data/logo.png", "data/logo.png", "data/logo.png");


            try
            {
                b.AddNewBeer(null);
                Assert.Fail();
            }catch(Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }

            
            b.AddNewBeer(p);
            Assert.IsTrue(b.Bieres.Contains(p));
            
        }
    }
}