using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Produit
{
    /// <summary>
    /// Interface containing values needed to make a proposition
    /// </summary>
    public interface IProposition
    {
        /// <summary>
        /// Additional informations
        /// </summary>
        public string Others { get; set; }

        /// <summary>
        /// Reset Additional informations
        /// </summary>
        public void ResetOthers();

        /// <summary>
        /// Add Propostion to a Definitiv Version
        /// </summary>
        public void AddToFinalDictionary();
    }
}
