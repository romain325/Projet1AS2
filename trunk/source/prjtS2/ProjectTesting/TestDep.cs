using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.Ressources;
using prjtS2.Persistance;
using prjtS2.Persistance.JsonPersistance;
using prjtS2.Persistance.JsonPersistance.Produit;
using prjtS2.Persistance.XmlPersistance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace ProjectTesting
{
    /// <summary>
    /// Another crash test class, mostly used for DataBase Interaction
    /// </summary>
    public class TestDep
    {
        public TestDep()
        {

            TestJson();
        }

        public void TestJson()
        {
            /*
            JsonSpec t = new JsonSpec();
            t.AddAllToFile();

            t.GetDicoAllFromFile();
            foreach (var r in Ressource.Parameter.DICO_SPEC)
            {
                Console.WriteLine(r.Key +"  "+ r.Value);
            }


            //t.UpdateOneFromFile("poivre", new Specificite("sel","Une légère touche salé"));

            t.AddOneToFile(new Specificite("sel", "Une légère touche salé "));

            t.GetDicoAllFromFile();
            foreach (var r in Ressource.Parameter.DICO_SPEC)
            {
                Console.WriteLine(r.Key + "  " + r.Value);
            }

            */

            /*
            for (int i = 0; i < Ressource.CountryArrays.Abbreviations.Count; i++)
            {
                new Localisation(Ressource.CountryArrays.Abbreviations[i], Ressource.CountryArrays.Names[i]);
            }

            */



            //DbDataManager db = new DbDataManager();
            /*
             prjtS2.FunctLibrary.Brasserie b3 = new prjtS2.FunctLibrary.Brasserie("oui", "ouioui", new Localisation("fr"));
             prjtS2.FunctLibrary.Brasserie b13 = new prjtS2.FunctLibrary.Brasserie("ouiEtNon", "ouioui", new Localisation("fr"));
            Brasserie b35 = new prjtS2.FunctLibrary.Brasserie("EnftEuhJSP", "ouioui", new Localisation("fr"));

             prjtS2.FunctLibrary.Biere b = new prjtS2.FunctLibrary.Biere("oui", "oui", (float)1.2, (float)3.5, "oui",
        new prjtS2.FunctLibrary.DetailBiere.Apparence(
            new Couleur("ambre"),
            new List<prjtS2.FunctLibrary.Ressources.Style>() { new prjtS2.FunctLibrary.Ressources.Style("dore") }),
        new prjtS2.FunctLibrary.DetailBiere.Gout(
            new List<Cereale>() { new Cereale("riz") },
            new List<TypeBiere>() { new TypeBiere("ipa"), new TypeBiere("lager") },
            new List<Specificite>() { new Specificite("poivre") },
            new List<Arome>() { new Arome("amer") }));

            Biere b2 = new prjtS2.FunctLibrary.Biere("ouiMaiLautre", "oui", (float)1.2, (float)3.5, "oui",
                new prjtS2.FunctLibrary.DetailBiere.Apparence(
                    new Couleur("brune"),
                    new List<prjtS2.FunctLibrary.Ressources.Style>() { new prjtS2.FunctLibrary.Ressources.Style("dore") }),
                new prjtS2.FunctLibrary.DetailBiere.Gout(
                    new List<Cereale>() { new Cereale("ble") },
                    new List<TypeBiere>() { new TypeBiere("ipa") },
                    new List<Specificite>() { new Specificite("poivre") },
                    new List<Arome>() { new Arome("amer") }));

            */

            /*
            var test = prjtS2.FunctLibrary.Tools.Crypto.Encrypt.EncryptString("AdminMode101", "SaltNVinegar");

            using(BinaryReader br = new BinaryReader(new StreamReader(@"F:/Prog\prjtS2\trunk\source\prjtS2\prjtS2.MainApp\data\Unsecure.bin")))
            {
                string s = br.ReadString();
                Console.WriteLine(s);
                var anotherRep = prjtS2.FunctLibrary.Tools.Crypto.Encrypt.DecryptString(s, "SaltNVinegar");
                Console.WriteLine(anotherRep);

            }

            //string test = System.IO.File.ReadAllText(@"F:\Prog\prjtS2\trunk\source\prjtS2\prjtS2.MainApp\data\EncodedMe.txt");
            var rep = prjtS2.FunctLibrary.Tools.Crypto.Encrypt.DecryptString(test, "SaltNVinegar");
            Console.WriteLine(test);
            Console.WriteLine(rep);
            
    */
            
            Console.WriteLine();
           



        }

        public void TestXML()
        {
            XmlLecon t = new XmlLecon();
            t.AddAllToFile();


            //t.UpdateOneFromFile("Alors la", new Lecon("test1", "c la joie", "data/logo.png"));
            t.AddOneToFile(new Lecon("lecon c cool", "sreieux how did i Managed this?", "data/logo.png"));
            t.AddOneToFile(new Lecon("quell genie", "sreieux how did i Managed this?", "data/logo.png"));
            t.AddOneToFile(new Lecon("AAAAAAAAAAAAAAAAAA", "sreieux how did i Managed this?", "data/logo.png"));
            t.AddOneToFile(new Lecon("Je suis un grec ", "sreieux how did i Managed this?", "data/logo.png"));


            t.GetDicoAllFromFile();
            foreach (var r in Library.LECON.Values)
            {
                Console.WriteLine(r.Nom + r.Description);
            }


            //t.RemoveOneFromFile("lecon c cool");
            t.GetDicoAllFromFile();
            foreach (var r in Library.LECON.Values)
            {
                Console.WriteLine(r.Nom + r.Description);
            }
        }
    }
}
