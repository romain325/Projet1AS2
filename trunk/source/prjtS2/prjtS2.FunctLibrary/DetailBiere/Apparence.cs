using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.DetailBiere
{
    /// <summary>
    /// First Part of the Beer Details Informations, all about the look of it
    /// </summary>
    public class Apparence : IApparence
    {
        /// <summary>
        /// Countains the color of the beer
        /// </summary>
        public Couleur couleur { get; }

        /// <summary>
        /// List of the different physical aspects of the beer
        /// </summary>
        public List<Style> Styles { get; }

        /// <summary>
        /// Default constructor taken a color and a list of style, if the list is empty, set to "Non Indiqué", same if color is null
        /// </summary>
        /// <param name="couleur">Color of the beer</param>
        /// <param name="styles">Physical aspects of the beer</param>
        public Apparence(Couleur couleur, List<Style> styles)
        {
            if (couleur is null) { this.couleur = new Couleur("na"); }
            else
            {
                this.couleur = couleur;
            }
            if (styles.Count == 0) { styles.Add(new Style("na")); }
            this.Styles = styles;
        }

        /// <summary>
        /// Basic ToString value, Used for Debugging
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string final = "Here is the color:" + couleur.ToString() + "\n And here is the different styles:\n";
            foreach (Style st in Styles)
            {
                final += "\t" + st + "\n";
            }

            return final;
        }
    }
}
