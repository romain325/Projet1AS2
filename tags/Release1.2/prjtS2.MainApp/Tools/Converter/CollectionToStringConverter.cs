using prjtS2.FunctLibrary.Ressources;
using prjtS2.FunctLibrary.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using Style = prjtS2.FunctLibrary.Ressources.Style;

namespace prjtS2.MainApp.Tools
{
    /// <summary>
    /// Converter class used to transform Collection passed to a string representation of it
    /// </summary>
    public class CollectionToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value is List<TypeBiere>)
            {
                return new CollectionToString().ListToString(value as List<TypeBiere>, CollectionToStringType.LineBreakComa, CollectionToStringType.Sharp);
            }
            if (value is List<Arome>)
            {
                return new CollectionToString().ListToString(value as List<Arome>, CollectionToStringType.LineBreakComa, CollectionToStringType.Sharp);
            }
            if (value is List<Cereale>)
            {
                return new CollectionToString().ListToString(value as List<Cereale>, CollectionToStringType.LineBreakComa, CollectionToStringType.Sharp);
            }
            if (value is List<Style>)
            {
                return new CollectionToString().ListToString(value as List<Style>, CollectionToStringType.LineBreakComa, CollectionToStringType.Sharp);
            }
            if (value is List<Specificite>)
            {
                return new CollectionToString().ListToString(value as List<Specificite>, CollectionToStringType.LineBreakComa, CollectionToStringType.Sharp);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
