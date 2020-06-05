using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.DetailBiere
{
    /// <summary>
    /// Second Part of the Beer Details Informations, all about the taste of it
    /// </summary>
    public class Gout : IGout
    {
        /// <summary>
        /// Default constructor taking lists of all the differents informations we want to know
        /// Every parameter set to "Non Indiqué" if list is empty
        /// </summary>
        /// <param name="cereales">Cereals contained</param>
        /// <param name="types">Types of Beer</param>
        /// <param name="specificites">Specificities of the beer</param>
        /// <param name="aromes">Taste of the beer</param>
        public Gout(List<Cereale> cereales, List<TypeBiere> types, List<Specificite> specificites, List<Arome> aromes)
        {
            if (cereales.Count == 0) { cereales.Add(new Cereale("na")); }
            if (types.Count == 0) { types.Add(new TypeBiere("na")); }
            if (specificites.Count == 0) { specificites.Add(new Specificite("na")); }
            if (aromes.Count == 0) { aromes.Add(new Arome("na")); }
            Cereales = cereales;
            Types = types;
            Specificites = specificites;
            Aromes = aromes;
        }

        /// <summary>
        /// Cereales List
        /// </summary>
        public List<Cereale> Cereales { get; }

        /// <summary>
        /// Types List
        /// </summary>
        public List<TypeBiere> Types { get; }

        /// <summary>
        /// Specificities List
        /// </summary>
        public List<Specificite> Specificites { get; }

        /// <summary>
        /// Tastes List
        /// </summary>
        public List<Arome> Aromes { get; }


        /// <summary>
        /// Basic ToString, Used for debugging
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string final = "Voici le détail du gout: \nLes différents céréales:\n";
            foreach (Cereale c in Cereales)
            {
                final += "\t" + c.ToString() + "\n";
            }

            final += "Les différents Types:\n";
            foreach (TypeBiere t in Types)
            {
                final += "\t" + t.ToString() + "\n";
            }

            final += "Ces spécificités:\n";
            foreach (Specificite s in Specificites)
            {
                final += "\t" + s.ToString() + "\n";
            }

            final += "Et ces aromes:\n";
            foreach (Arome a in Aromes)
            {
                final += "\t" + a.ToString() + "\n";
            }

            return final;
        }
    }
}
