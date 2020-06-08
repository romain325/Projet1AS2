using Newtonsoft.Json;
using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace prjtS2.FunctLibrary.Produit
{
    /// <summary>
    /// Class containing all the data about a Brewery
    /// </summary>
    public class Brasserie : Produit, IBrasserie
    {

        /// <summary>
        /// Contains a list of all the beer a Brewery produce or used to produce
        /// </summary>
        public List<Biere> Bieres = new List<Biere>();

        /// <summary>
        /// Represente the origin of the Brewery
        /// </summary>
        public Localisation Loc { get; }

        /// <summary>
        /// Create and Instantiate a new Brewery
        /// </summary>
        /// <param name="nom">Name</param>
        /// <param name="description">Desccription</param>
        /// <param name="localisation">Localisation of the brewery</param>
        /// <param name="img1">Image of the brewery</param>
        /// <param name="img2">Image of the brewery</param>
        /// <param name="img3">Image of the brewery</param>
        /// <param name="nbNotes">Total number of notes recieved</param>
        /// <param name="noteTotal">Total of notes recieved</param>
        public Brasserie(string nom, string description, Localisation localisation, string img1, string img2, string img3, int nbNotes = 1, long noteTotal = 50) : base(nom, description, nbNotes, noteTotal)
        {
            if (nom is null || nom == "" || description is null || description == "" || localisation is null) { throw new ArgumentException("Some values are null, and we don't allow that!"); }
            this.Loc = localisation;
            Images.Add(img1);
            Images.Add(img2);
            Images.Add(img3);

            //Add to Brewery Dictionary
            Library.DICO_BRASSERIES.Add(this.Nom.ToLower(), this);
        }

        /// <summary>
        /// With this function we can add a new beer to our Propreties 'Bières'
        /// </summary>
        /// <param name="biere">The beer we want to add</param>
        public void AddNewBeer(Biere biere)
        {
            if (biere is null) { throw new ArgumentException("The beer you gived us is null! We can't add it!"); }
            Bieres.Add(biere);
        }

        /// <summary>
        /// Réecriture simple du ToString pour tout faire apparaitre, Used For Debugging
        /// </summary>
        /// <returns>La valeur finit de notre toString</returns>
        public override string ToString()
        {
            string final = "Description of the " + Nom + "Brewery\n";
            final += "Quick Description: \n\t" + Description + "\n";
            final += "Localisation:" + Loc.ToString() + "\n";
            if (Bieres.Count == 0)
            {
                final += "This brewery does not have any Beer attribuated yet :/";
            }
            else
            {
                final += "Beer:\n";
                foreach (Biere b in Bieres)
                {
                    final += "\t" + b.Nom.ToString() + "\n";
                }
            }
            return final + "\n\n";
        }

    }
}
