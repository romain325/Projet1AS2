using System;
using System.Collections.Generic;
using System.Text;
using prjtS2.FunctLibrary.Ressources;

namespace prjtS2.FunctLibrary
{
    /// <summary>
    /// Implementation of the Adding Bloc displayed at each end of content list
    /// This bloc can propose to create a Beer or a Brewery
    /// </summary>
    public class BlocAjout : BaseElement
    {
        /// <summary>
        /// Default constructor setting his image to default pics and calling BaseElement
        /// </summary>
        /// <param name="nom">Name/Title of the Bloc</param>
        /// <param name="description">Description of the Bloc</param>
        public BlocAjout(string nom, string description) : base(nom, description)
        {
            Images.Add("data/logo.png");
        }

    }
}
