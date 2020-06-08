using prjtS2.FunctLibrary.Compte;
using prjtS2.FunctLibrary.Produit;
using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace prjtS2.FunctLibrary
{
    /// <summary>
    /// Contains all the differents dictionary useful for search and listing
    /// </summary>
    public class Library
    {

        /// <summary>
        /// A Dictionnary containing all the Brewery we have in our dataBase
        /// </summary>
        public static Dictionary<string, Brasserie> DICO_BRASSERIES = new Dictionary<string, Brasserie>();

        /// <summary>
        /// A Dictionary containing all the Beer we have in our Database
        /// </summary>
        public static Dictionary<string, Biere> DICO_BIERES = new Dictionary<string, Biere>();

        /// <summary>
        /// A Dictionnary containing all the Brewery in a waiting state
        /// </summary>
        public static Dictionary<string, PropBiere> PROP_BIERES = new Dictionary<string, PropBiere>();

        /// <summary>
        /// A Dictionnary containing all the Beer in a waiting state
        /// </summary>
        public static Dictionary<string, PropBrasserie> PROP_BRASSERIES = new Dictionary<string, PropBrasserie>();

        /// <summary>
        /// Contains all the known profil username
        /// </summary>
        public static List<string> COMPTES { get; } = new List<string>();
        /// <summary>
        /// List of all the Admin Profil
        /// </summary>
        public static List<string> ADMIN_PROFIL = new List<string>();

        /// <summary>
        /// Contains the different lessons
        /// </summary>
        public static Dictionary<string, Lecon> LECON = new Dictionary<string, Lecon>();


        /// <summary>
        /// Contains the differents types of blocs that can be instanciated, you can add more and update BlocInfo in the BlocAjout dedicated part
        /// </summary>
        public static Dictionary<Ressource.BlocType, BlocAjout> ADD_BLOCK = new Dictionary<Ressource.BlocType, BlocAjout>()
        {
            {Ressource.BlocType.Biere, new BlocAjout("Pas de trace de votre Bière préferé?", "Proposez la nous Ici et nous pourrons l'ajouter après vérification! (Remplisser tout les champs pour etre revu plus vite!)") },
            {Ressource.BlocType.Brasserie, new BlocAjout("Pas de trace de votre Brasserie préferé?", "Proposez la nous Ici et nous pourrons l'ajouter après vérification ! (Remplisser tout les champs pour etre revu plus vite!)") }
        };

    }
}
