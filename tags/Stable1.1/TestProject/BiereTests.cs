using Microsoft.VisualStudio.TestTools.UnitTesting;
using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.Compte;
using prjtS2.FunctLibrary.DetailBiere;
using prjtS2.FunctLibrary.Produit;
using prjtS2.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Tests
{
    /// <summary>
    /// Test Class Dedicated to the MainBeer Function Test
    /// </summary>
    [TestClass()]
    public class BiereTests
    {
        DbDataManager db = new DbDataManager();
        Brasserie brass = new Brasserie("test","testdesc",new Ressources.Localisation("fr"), "data/logo.png", "data/logo.png", "data/logo.png");
        Apparence apparence = new Apparence(new Ressources.Couleur("rouge"), new List<Ressources.Style>());
        Gout gout = new Gout(new List<Ressources.Cereale>(),new List<Ressources.TypeBiere>(), new List<Ressources.Specificite>(), new List<Ressources.Arome>() );
        
        /// <summary>
        /// Constructor when he should send Exception
        /// </summary>
        [TestMethod()]
        public void BiereTestFail()
        {
            try
            {
               var p = new Biere("del", "", 0, 0, "test", null, null, "data/logo.png", "data/logo.png", "data/logo.png");
            }catch(Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            try
            {
                var p = new Biere("del", "test", 0, 0, "test", apparence, null, "data/logo.png", "data/logo.png", "data/logo.png");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            try
            {
                var p = new Biere("del", "test", 0, 0, "test", null, gout, "data/logo.png", "data/logo.png", "data/logo.png");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
        }

        /// <summary>
        /// Constructor when he should work properly
        /// </summary>
        [TestMethod()]
        public void BiereTestWork()
        {
            try
            {
                var p = new Biere("del", "desc", 0, 0, "test", apparence, gout, "data/logo.png", "data/logo.png", "data/logo.png");
                Assert.IsTrue(Library.DICO_BIERES.ContainsKey("del"));
                Assert.IsTrue(p.Gout.Cereales.Count != 0);
                Assert.IsTrue(p.Gout.Aromes.Count != 0);
                Assert.IsTrue(p.Gout.Specificites.Count != 0);
                Assert.IsTrue(p.Gout.Types.Count != 0);
                Assert.IsTrue(p.Apparence.Styles.Count != 0);
            }
            catch
            {
                Assert.Fail();
            }
        }

    }
}