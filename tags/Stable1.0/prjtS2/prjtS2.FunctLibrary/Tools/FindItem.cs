using AutoFixture.Kernel;
using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Tools
{
    /// <summary>
    /// Find in a RessourceAccess derived class if Value is in a List
    /// </summary>
    /// <typeparam name="T"> Ressource Access Derived class </typeparam>
    public static class FindItem<T> where T : RessourceAccess
    {
        /// <summary>
        /// CHeck if Values is contained in Ressource 
        /// If So return true
        /// </summary>
        /// <param name="val">value</param>
        /// <param name="list">List where we need to check</param>
        /// <returns>If the value is contained in the list</returns>
        public static bool ContainsValue(string val, List<T> list)
        {
            foreach(T u in list)
            {
                if (u.Value == val) { return true; }
            }
            return false;
        }
    }
}
