using Microsoft.VisualStudio.TestTools.UnitTesting;
using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.Compte;
using prjtS2.FunctLibrary.Ressources;
using prjtS2.Persistance;
using System;
using System.Collections.Generic;

namespace TestProject
{
    /// <summary>
    /// Test Class Dedicated to the MainProfil Function Test
    /// </summary>
    [TestClass]
    public class ProfilTest
    {
        /// <summary>
        /// Function dedicated to test A Profil Creation
        /// </summary>
        [TestMethod]
        public void TestProfilCreate()
        {
            DbDataManager db = new DbDataManager();
            Profil p = new Profil("Rom1","olivier","romain","EncryptMe","test@gmail.com",new System.DateTime(2001,10,16), new Localisation("fr"), "Vous n'avez pas encore de description","data/logo.png", false);

            Assert.AreEqual(p.Nom, "olivier");
            Assert.AreEqual(p.Prenom, "romain");
            Assert.AreEqual(p.Username, "Rom1");
            Assert.IsTrue(Library.COMPTES.Contains("Rom1"));
            Assert.IsFalse(Library.ADMIN_PROFIL.Contains("Rom1"));
            Assert.AreNotEqual(p.Password, "EncryptMe");
            Assert.AreEqual(p.Mail, "test@gmail.com");
            Assert.AreEqual(p.Age, 18);
            Assert.AreEqual(p.Localisation.Value, "France");
            Assert.AreEqual(p.Biographie, "Vous n'avez pas encore de description");
        }


        /// <summary>
        /// Function dedicated to test A Profil Connection
        /// </summary>
        [TestMethod]
        public void TestProfilConnect()
        {
            DbDataManager db = new DbDataManager();
            Profil p = db.ProfilData.GetOneFromFile("roro");

            Assert.AreEqual(p.Nom, "OLIVIER");
            Assert.AreEqual(p.Prenom, "Romain");
            Assert.AreEqual(p.Username, "roro");
            Assert.IsTrue(Library.COMPTES.Contains("roro"));
            Assert.IsTrue(Library.ADMIN_PROFIL.Contains("roro"));
            Assert.AreNotEqual(p.Password, "oui");
            Assert.AreEqual(p.Mail, "rom1@mail.com");
            Assert.AreEqual(p.Age, 18);
            Assert.AreEqual(p.Localisation.Value, "Japan");
            Assert.AreNotEqual(p.Biographie, "Vous n'avez pas encore de description");
        }

        /// <summary>
        /// Function dedicated to test A Profil Creation When the Username is Already taken
        /// </summary>
        [TestMethod]
        public void TestProfilCreateAlreadExist()
        {
            DbDataManager db = new DbDataManager();
            Action act = () => new Profil("roro", "olivier", "romain", "EncryptMe", "test@gmail.com", new System.DateTime(2001, 10, 16), new Localisation("fr"), "Vous n'avez pas encore de description", "data/logo.png", false);
            Assert.ThrowsException<Exception>(act);
        }

        /// <summary>
        /// Function dedicated to test A Profil Creation when the wrong infos are passed
        /// </summary>
        [TestMethod]
        public void TestProfilCreateWrongInfo()
        {
            DbDataManager db = new DbDataManager();
            Action act = () => new Profil("kebab", "olivier", "romain", "EncryptMe", "test.com", new System.DateTime(2006, 10, 16), new Localisation("rg"), "Vous n'avez pas encore de description", "data/logo.png", false);
            Assert.ThrowsException<Exception>(act);
        }

        /// <summary>
        /// Function dedicated to test A Profil when you had Imperatifs and if the The bool return does update well
        /// </summary>
        [TestMethod]
        public void TestProfilAddImpérafits()
        {
            DbDataManager db = new DbDataManager();
            Profil p = db.ProfilData.GetOneFromFile("roro");
            p.imperatifs.Add(Allergene.ALCOOL);
            p.imperatifs.Add(Allergene.GLUTEN);
            p.imperatifs.Add(Allergene.LEVURE);

            Assert.IsTrue(p.HasAlcool);
            Assert.IsTrue(p.HasGluten);
            Assert.IsTrue(p.HasLevure);
            Assert.IsTrue(p.HasAll);
            Assert.IsFalse(p.HasNone);
        }

        /// <summary>
        /// Function dedicated to test A Profil when you modify your profil with wrong informations
        /// </summary>
        [TestMethod]
        public void TestProfilModifWrongInfo()
        {
            DbDataManager db = new DbDataManager();
            var p = new Profil("Rom1", "olivier", "romain", "EncryptMe", "test@gmail.com", new System.DateTime(2001, 10, 16), new Localisation("fr"), "Vous n'avez pas encore de description", "data/logo.png", false);
            try
            {
                p.Nom = "";
                Assert.Fail("No Exception thrown");
            }catch(Exception e)
            {
                Assert.IsTrue(e is Exception);
                Assert.AreEqual(p.Nom, "olivier");
            }
        }
    }
}
