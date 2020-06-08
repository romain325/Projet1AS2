using prjtS2.FunctLibrary.DetailBiere;
using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Produit
{
    /// <summary>
    /// Class containing all the Informations about a Beer
    /// </summary>
    public class Biere : Produit, IHasAllergenes, IBiere
    {
        /// <summary>
        /// A floating number for the conseilled price of this beer
        /// </summary>
        public float PrixMoyen { get; }

        /// <summary>
        /// A floating number representing the number of Degrees of this beer
        /// </summary>
        public float Degrees { get; }

        /// <summary>
        /// Represents the brewery from where this beer is from
        /// </summary>
        public Brasserie Brasserie;

        /// <summary>
        /// It contains a list of all the Allergens the beer contains
        /// </summary>
        public List<Allergene> Allergenes { get; } = new List<Allergene>();

        /// <summary>
        /// The Apparence class contains all the informations about how the beer looks
        /// </summary>
        public Apparence Apparence { get; }

        /// <summary>
        /// The Gout class contains all the informations about how the beer tastes
        /// </summary>
        public Gout Gout { get; }

        /// <summary>
        /// The localisation is based on the Brasserie Localisation
        /// </summary>
        public Localisation Loc { get => Brasserie.Loc; }


        /// <summary>
        /// Instantiate the Beer Data
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
        /// <param name="alcool">Does it Contains Alcool?</param>
        /// <param name="levure">Does it Contains Levure?</param>
        /// <param name="gluten">Does it Contains Gluten?</param>
        /// <param name="nbNotes">Number of notes the beer recieved</param>
        /// <param name="noteTotal">Total mark of all combined</param>
        public Biere(string nom, string description, float degrees, float prixMoyen, string brasserie, Apparence apparence, Gout gout, string img1, string img2, string img3, bool alcool = true, bool levure = true, bool gluten = true, int nbNotes = 1, long noteTotal = 50) : base(nom, description, nbNotes, noteTotal)
        {
            ///Check if informations are null or not
            if (apparence is null || gout is null || nom is null || nom == "" || description is null || description == "") { throw new ArgumentException("Some values are null, and we don't allow that!"); }

            ///Check if the brewery exist in the database and if so add the beer to the brewery 
            if (Library.DICO_BRASSERIES.ContainsKey(brasserie.ToLower()))
            {
                this.Brasserie = Library.DICO_BRASSERIES[brasserie.ToLower()];
                this.Brasserie.AddNewBeer(this);
            }
            else
            {
                throw new ArgumentException("This Brewery Doesn't exist");
            }

            this.PrixMoyen = prixMoyen;
            this.Degrees = degrees;
            this.Apparence = apparence;
            this.Gout = gout;

            ///Set different Allergenes contained in the beer
            if (alcool) { Allergenes.Add(Allergene.ALCOOL); }
            if (levure) { Allergenes.Add(Allergene.LEVURE); }
            if (gluten) { Allergenes.Add(Allergene.GLUTEN); }

            ///Add the different images to the list
            Images.Add(img1);
            Images.Add(img2);
            Images.Add(img3);

            ///Add the beer to the Dictionnary
            Library.DICO_BIERES.Add(this.Nom.ToLower(), this);
        }

        /// <summary>
        /// Return if the beer contains Glutens or Not
        /// </summary>
        public bool HasGluten
        {
            get
            {
                return Allergenes.Contains(Allergene.GLUTEN);
            }
        }

        /// <summary>
        /// Return if the beer contains Yeast or Not
        /// </summary>
        public bool HasLevure
        {
            get
            {
                return Allergenes.Contains(Allergene.LEVURE);
            }
        }

        /// <summary>
        /// Return if the beer contains Alcohol or Not
        /// </summary>
        public bool HasAlcool
        {
            get
            {
                return Allergenes.Contains(Allergene.ALCOOL);
            }
        }

        /// <summary>
        /// Return if the beer contains All the Allergens or Not
        /// </summary>
        public bool HasAll
        {
            get
            {
                return HasAlcool && HasGluten && HasLevure;
            }
        }

        /// <summary>
        /// A Classic to string to print out all the informations, Used For Debugging
        /// </summary>
        /// <returns>All the infromations about the beer</returns>
        public override string ToString()
        {
            string final = "Voici les détail de cette bière: \n";
            final += Nom + " " + this.Description + " " + Degrees + " " + PrixMoyen + " " + Brasserie + "\n";
            final += Apparence.ToString() + "\n\n" + Gout.ToString();
            return final;
        }
    }
}
