using Microsoft.VisualStudio.TestTools.UnitTesting;
using prjtS2.FunctLibrary.Ressources;
using prjtS2.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    [TestClass()]
    public class RessourceAccesTest
    {
        DbDataManager db = new DbDataManager();
        ///We will use the derived class called Localisaton, but in fact it's just to test the abstract class RessourceAccess
        ///Because all the derived doesn't change anything except the Library used and the SaveFile

        [TestMethod()]
        public void RsrcTestFail()
        {
            ///Accessing Data
            try
            {
                Localisation l = new Localisation(null);
                Assert.Fail();
            }catch(Exception e)
            {
                Assert.IsTrue(e is Exception);
            }
            try
            {
                Localisation l = new Localisation("kebab");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is Exception);
            }


            ///Creating Data
            try
            {
                Localisation l = new Localisation(null,null);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is Exception);
            }

            try
            {
                Localisation l = new Localisation("fr", "BieloRussie Médievale");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is Exception);
            }
        }

        [TestMethod()]
        public void RsrcTestSuccess()
        {
            var l = new Localisation("fr");
            Assert.AreEqual(l.Key, "fr");
            Assert.AreEqual(l.Value, "France");

            var l2 = new Localisation("leval", "Levallois Land");
            Assert.AreEqual(l2.Key, "leval");
            Assert.AreEqual(l2.Value, "Levallois Land");
            Assert.IsTrue(Ressource.Parameter.CountryArrays.ContainsKey("leval"));

        }


        [TestMethod()]
        public void RsrcTestContainsKey()
        {
            var l = new Localisation("fr");
            Assert.IsTrue( l.CheckExist("fr"));
            Assert.IsFalse( l.CheckExist("patouLabou"));
            try
            {
                l.CheckExist(null);
                Assert.Fail();
            }catch(Exception e)
            {
                Assert.IsTrue(e is Exception);
            }
            
           
        }

    }
}
