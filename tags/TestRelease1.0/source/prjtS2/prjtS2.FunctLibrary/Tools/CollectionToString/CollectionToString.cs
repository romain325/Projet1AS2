using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace prjtS2.FunctLibrary.Tools
{
    /// <summary>
    /// Class allowing CollectionToString transformation with personnalized Before and After Separator
    /// </summary>
    public class CollectionToString : ICollectionToString
    {
        /// <summary>
        /// Get Selected Seperator from Enum
        /// </summary>
        /// <param name="type">Type of separator</param>
        /// <returns>the Separator used</returns>
        public string GetSeparator(CollectionToStringType type)
        {
            switch (type)
            {
                case CollectionToStringType.LineBreak:
                    return "\n";
                case CollectionToStringType.LineBreakComa:
                    return ",\n";
                case CollectionToStringType.InLineSpace:
                    return " ";
                case CollectionToStringType.InLineComa:
                    return ", ";
                case CollectionToStringType.SlashSlash:
                    return "// ";
                case CollectionToStringType.None:
                    return "";
                case CollectionToStringType.Sharp:
                    return "#";
            }
            return " ";
        }

        /// <summary>
        /// Dictionary Values To String
        /// </summary>
        /// <typeparam name="Tk">KeyType</typeparam>
        /// <typeparam name="T">ValueType</typeparam>
        /// <param name="dico">Dictionnary</param>
        /// <param name="type">After Separator</param>
        /// <param name="before">Before Separator</param>
        /// <returns>String of the Dico Values</returns>
        public string DictionaryValueToString<Tk, T>(IDictionary<Tk, T> dico, CollectionToStringType type = CollectionToStringType.LineBreak, CollectionToStringType before = CollectionToStringType.None) where T : class
        {
            return ACollectionToString<T>(dico.Values, type);
        }

        /// <summary>
        /// Collection To String
        /// </summary>
        /// <typeparam name="T">ValueType</typeparam>
        /// <param name="collec">Collection of Values</param>
        /// <param name="type">After Separator</param>
        /// <param name="before">Before Separator</param>
        /// <returns>String of the Values</returns>
        public string ACollectionToString<T>(ICollection<T> collec, CollectionToStringType type = CollectionToStringType.LineBreakComa, CollectionToStringType before = CollectionToStringType.None)
        {
            if(collec is null) { return null; }
            if(collec.Count == 0) { return null; }
            string sep = GetSeparator(type);
            string pre = GetSeparator(before);
            string final = "";
            foreach(T val in collec)
            {
                final += pre + val.ToString() + sep;
            }
            final = final.Remove(final.Length - sep.Length);
            return final;
        }

        /// <summary>
        /// List To String
        /// </summary>
        /// <typeparam name="T">ValueType</typeparam>
        /// <param name="collec">Collection of Values</param>
        /// <param name="type">After Separator</param>
        /// <param name="before">Before Separator</param>
        /// <returns>String of the Values</returns>
        public string ListToString<T>(IList<T> list, CollectionToStringType type = CollectionToStringType.LineBreak, CollectionToStringType before = CollectionToStringType.None)
        {
            return ACollectionToString<T>(list, type,before);
        }
        
    }
}
