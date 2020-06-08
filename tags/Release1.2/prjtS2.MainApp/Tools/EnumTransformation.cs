using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace prjtS2.MainApp.Tools
{
    /// <summary>
    /// Class used to transform enum by using [Description] Attribute
    /// </summary>
    public static class EnumTransformation
    {
        /// <summary>
        /// Get all the Description of every element in the Enum
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns>Collection of [Description]Attribute</returns>
        public static ICollection<string> GetDescriptionFromValueList<T>() where T : Enum
        {
            ICollection<string> Source = new List<string>();

            var type = typeof(T);

            foreach(var i in type.GetEnumValues())
            {
                var test = (i.GetType().GetField(i.ToString()).GetCustomAttributes(typeof(DescriptionAttribute),true).First() as DescriptionAttribute).Description;
                Source.Add(test);
            }

            return Source;
        }


        /// <summary>
        /// Get Enum Value by passing Enum Values 
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <param name="index">Index in the enum</param>
        /// <returns>Enum Value</returns>
        public static T GetValueFromIndex<T>(int index) where T : Enum
        {
            var type = typeof(T);
            if (index > type.GetEnumValues().Length || index < 0  ) { return (T)type.GetEnumValues().GetValue(0); }
            return (T)type.GetEnumValues().GetValue(index);

        }
    }
}
