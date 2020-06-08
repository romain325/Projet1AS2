using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace prjtS2.MainApp.Tools
{
    /// <summary>
    /// Converter Class used to transform string into a Bitmap value so Wpf can display it on the run
    /// </summary>
    public class UriToBitMapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is null) { return null; }            
            var img = new BitmapImage(new Uri(value.ToString(), UriKind.Relative));
            Debug.Write(img.PixelWidth);
            return img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
