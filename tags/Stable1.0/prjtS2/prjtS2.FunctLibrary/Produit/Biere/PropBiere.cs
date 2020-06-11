using prjtS2.FunctLibrary.DetailBiere;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Produit
{
    /// <summary>
    /// Derived Class of Beer allowing to create a Proposition that everybody can do 
    /// </summary>
    public class PropBiere : Biere, IProposition
    {
        /// <summary>
        /// Informations about everything that can't be described with actual existing parameter
        /// </summary>
        public string Others { get; set; } = null;

        /// <summary>
        /// Constructor derived from User, same parameter, just adding Others
        /// </summary>
        /// <param name="nom">Name of the Beer, used in lower case as Key (Immutable / Uniq)</param>
        /// <param name="description">Description and informations about the beer</param>
        /// <param name="degrees">Number of degrees of the beer</param>
        /// <param name="prixMoyen">Average Price of the beer</param>
        /// <param name="brasserie">The Brewery that create this beer</param>
        /// <param name="apparence">How does the beer looks</param>
        /// <param name="gout">How does the beer taste</param>
        /// <param name="img1">First Image, set to default if null or empty</param>
        /// <param name="img2">Second Image, set to default if null or empty</param>
        /// <param name="img3">Third Image, set to default if null or empty</param>
        /// <param name="other">Other informations that can't be added from acctual parameters</param>
        /// <param name="alcool">Does it Contains Alcool?</param>
        /// <param name="levure">Does it Contains Levure?</param>
        /// <param name="gluten">Does it Contains Gluten?</param>
        /// <param name="nbNotes">Number of notes the beer recieved</param>
        /// <param name="noteTotal">Total mark of all combined</param>
        public PropBiere(string nom, string description, float degrees, float prixMoyen, string brasserie, Apparence apparence, Gout gout, string img1, string img2, string img3,string other ,bool alcool = true, bool levure = true, bool gluten = true, int nbNotes = 1, long noteTotal = 50) : base(nom, description, degrees, prixMoyen, brasserie, apparence, gout, img1, img2, img3, alcool, levure, gluten, nbNotes, noteTotal)
        {
            Library.DICO_BIERES.Remove(nom.ToLower());
            Library.PROP_BIERES.Add(nom.ToLower(), this);
            this.Brasserie.Bieres.Remove(this);
            this.Others = other;
        }

        /// <summary>
        /// Reset the Others val to continue creation
        /// </summary>
        public void ResetOthers()
        {
            Others = null;
        }

        /// <summary>
        /// Transform the actual Class to a definitiv version of it in the real Dictionary
        /// </summary>
        public void AddToFinalDictionary()
        {
            if (Others is null || Others == "")
            {
                Library.PROP_BIERES.Remove(this.Nom.ToLower());
            }
            else
            {
                throw new Exception("Be sure to Implement and then Remove the 'Others' part!");
            }
        }
    }
}
