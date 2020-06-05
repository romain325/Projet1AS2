using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.Persistance
{
    /// <summary>
    /// DataBase Facade used for Strategy choice in DataBaseManagement
    /// </summary>
    /// <typeparam name="T">Type of Class</typeparam>
    /// <typeparam name="TMethode">Type of Methode used</typeparam>
    public interface IGestion<T, TMethode> where T : class
    {
        /// <summary>
        /// File Where Data is saved
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Add all loaded val to file
        /// </summary>
        void AddAllToFile();

        /// <summary>
        /// Add one Entity to file
        /// </summary>
        /// <param name="NewEntity">Class who need to be send to data</param>
        void AddOneToFile(T NewEntity);

        /// <summary>
        /// Get Dictionary created from file data
        /// </summary>
        void GetDicoAllFromFile();

        /// <summary>
        /// Remove One Entity ffrom file by his key
        /// </summary>
        /// <param name="entity">Key used</param>
        void RemoveOneFromFile(string entity);

        /// <summary>
        /// Update a value from file
        /// </summary>
        /// <param name="OldEntity">key from old entity</param>
        /// <param name="NewEntity">class of the new entity</param>
        void UpdateOneFromFile(string OldEntity, T NewEntity);

        /// <summary>
        /// Save All data to file
        /// </summary>
        /// <param name="document"></param>
        void SaveAllData(TMethode document);

        /// <summary>
        /// Loads Up the file needed to save data
        /// </summary>
        /// <returns>Type of Gestion used </returns>
        TMethode LoadFile();
    }
}
