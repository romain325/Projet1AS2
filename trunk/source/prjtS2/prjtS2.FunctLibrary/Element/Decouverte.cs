using prjtS2.FunctLibrary.Produit;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary
{
    /// <summary>
    /// Initiating of the Discovery class
    /// This class contains a list of beer sorted by certain settings
    /// </summary>
    public class Decouverte : BaseElement
    {
        /// <summary>
        /// Default Constructor taking a name, a list of beer and an Image
        /// </summary>
        /// <param name="nom">Name of this Discovery</param>
        /// <param name="bieres">List of beer sorted by a certain parameter, The result needs to have at least one result</param>
        /// <param name="imageLink">Image used on the bloc</param>
        /// <param name="description">Default set because never showed</param>
        public Decouverte(string nom, List<Biere> bieres,string imageLink, string description = "useless") : base(nom, description)
        {
            if(bieres.Count > 0 && bieres != null)
            {
                Bieres = bieres;
                Images.Add(imageLink);
            }
            else
            {
                throw new ArgumentException("The beer list given seems to be empty or null");
            }
        }

        private readonly List<Biere> Bieres;

        /// <summary>
        /// Return a random entity of the Beers List 
        /// </summary>
        public Biere Biere
        {
            get
            {
                Random rnd = new Random();
                return Bieres[rnd.Next(Bieres.Count)];
            }
        }
    }
}
