using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Tools
{
    /// <summary>
    /// Interfaces to make a new CollectionToString model
    /// </summary>
    public interface ICollectionToString
    {
        /// <summary>
        /// Return a separator from the collection 
        /// </summary>
        /// <param name="type">type of separator</param>
        /// <returns>separator</returns>
        string GetSeparator(CollectionToStringType type);

        /// <summary>
        /// The T class needs to have a ToString
        /// </summary>
        /// <typeparam name="Tk">Key Param</typeparam>
        /// <typeparam name="T">Value Param !! Needs to have have a ToString (default or overrided)!!</typeparam>
        /// <param name="dico">dictionnary</param>
        /// <param name="type">type of separator</param>
        /// <returns>string value of the collection</returns>
        public string DictionaryValueToString<Tk, T>(IDictionary<Tk, T> dico, CollectionToStringType type, CollectionToStringType before) where T : class;

        /// <summary>
        /// Transform the Collection of T in a string 
        /// </summary>
        /// <typeparam name="T">Value Param !! Needs to have have a ToString (default or overrided)!!</typeparam>
        /// <param name="collec">Collection</param>
        /// <param name="type">Type of Separator</param>
        /// <returns></returns>
        public string ACollectionToString<T>(ICollection<T> collec, CollectionToStringType type, CollectionToStringType before);

        /// <summary>
        /// Transform a list to a string
        /// </summary>
        /// <typeparam name="T">Value Param !! Needs to have have a ToString (default or overrided)!!</typeparam>
        /// <param name="list">List </param>
        /// <param name="type">Separator Type</param>
        /// <returns></returns>
        public string ListToString<T>(IList<T> list, CollectionToStringType type, CollectionToStringType before);

    }
}
