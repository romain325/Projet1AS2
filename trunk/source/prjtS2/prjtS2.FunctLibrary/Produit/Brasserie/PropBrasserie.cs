using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Produit
{
    /// <summary>
    /// Derived From the Brewery allowing everybody to create a Proposition of new Brewery
    /// </summary>
    public class PropBrasserie : Brasserie, IProposition
    {
        /// <summary>
        /// Others Informations that haven't been added with default parameter
        /// </summary>
        public string Others { get; set; } = null;

        /// <summary>
        /// Initiate a new PropBrasserie with Brasserie parameters and "others" field
        /// </summary>
        /// <param name="nom">Name</param>
        /// <param name="description">Desccription</param>
        /// <param name="localisation">Localisation of the brewery</param>
        /// <param name="img1">Image of the brewery</param>
        /// <param name="img2">Image of the brewery</param>
        /// <param name="img3">Image of the brewery</param>
        /// <param name="others">Additional informations</param>
        /// <param name="nbNotes">Total number of notes recieved</param>
        /// <param name="noteTotal">Total of notes recieved</param>
        public PropBrasserie(string nom, string description, Localisation localisation, string img1, string img2, string img3,string others, int nbNotes = 1, long noteTotal = 50) : base(nom, description, localisation, img1, img2, img3, nbNotes, noteTotal)
        {
            Library.DICO_BRASSERIES.Remove(nom.ToLower());
            Library.PROP_BRASSERIES.Add(nom.ToLower(), this);
            this.Others = others;
        }
 
        /// <summary>
        /// Action to transform the proposition into a definitive Version of this Brewery
        /// </summary>
        public void AddToFinalDictionary()
        {
            if(Others is null || Others == "")
            {
                Library.PROP_BRASSERIES.Remove(this.Nom.ToLower());
            }
            else
            {
                throw new Exception("Be sure to Implement and then Remove the 'Others' part!");
            }
        }

        /// <summary>
        /// Reset the Others Value
        /// </summary>
        public void ResetOthers()
        {
            Others = null;
        }
    }
}
