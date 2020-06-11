using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.Compte;
using prjtS2.FunctLibrary.DetailBiere;
using prjtS2.FunctLibrary.Ressources;
using prjtS2.FunctLibrary.Tools.WebRequest;
using prjtS2.Persistance.XmlPersistance;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProjectTesting
{
    /// <summary>
    /// Crash class used all over the project to test some little functions 
    /// I keeped it but with all the modifications it certainly don't work
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ConnexionHandler ConnexionHandler = new ConnexionHandler();
            try { 
                Apparence apparence = new Apparence(
                    Couleur.BLONDE,
                    new List<Style>()
                    {
                        new Style("dore"),
                        new Style("opaq")
                    }
                );

                Gout gout = new Gout(
                    new List<Cereale>() { Cereale.HOUBLON, Cereale.BLE },
                    new List<TypeBiere>()
                    {
                        new TypeBiere("ipa"),
                        new TypeBiere("ale")
                    },
                    new List<Specificite>()
                    {
                        new Specificite("null")
                    },
                    new List<Arome>()
                    {
                        new Arome("amer"),
                        new Arome("aigre")
                    }
                    );
                Localisation loc = new Localisation("fr");

                Brasserie brass = new Brasserie("Brass Random", "Une brasserie comme il'y en a des tonnes",loc);
                Biere biere = new Biere(
                    "Test Binouze",
                    "Une binouze on ne peut plus classique",
                    (float)2.17,
                    (float)3.50,
                    new List<Allergene>() { },
                    brass.Nom,
                    apparence,
                    gout
                    );

                Admin Ro = new Admin("kebab","Olivier","Romain","MaitreKebabier35","romainolivier42@gmail.com",
                    new DateTime(2001,10,16),
                    new Localisation("fr"));


                Console.WriteLine("InitDone");
                //Console.WriteLine( ConnexionHandler.CheckComptes("kebab", "Lumain03"));
                //foreach (Profil p in Library.COMPTES.Values)
                //{
                //Console.WriteLine(p.Nom +" " + p.Username);
                //}
                //Console.WriteLine(biere.ToString());

                
                


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            */

            //TestDep t = new TestDep();

            Console.WriteLine(InternetInteraction.CheckLinkIsJpgOrPng("https://www.thisiscolossal.com/wp-content/uploads/2018/04/agif2opt.gif"));

        }
    }
}
