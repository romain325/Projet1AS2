using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Ressources
{
    /// <summary>
    /// Interface containing Allergens interactions
    /// </summary>
    public interface IHasAllergenes
    {
        /// <summary>
        /// Take care of Alcool
        /// </summary>
        bool HasAlcool { get; }

        /// <summary>
        /// Take care of Gluten
        /// </summary>
        bool HasGluten { get; }

        /// <summary>
        /// Take care of Levure
        /// </summary>
        bool HasLevure { get; }

        /// <summary>
        /// Take care of All
        /// </summary>
        bool HasAll { get; }

    }
}
