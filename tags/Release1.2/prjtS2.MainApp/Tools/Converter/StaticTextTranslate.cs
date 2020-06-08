using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace prjtS2.MainApp.Tools.Converter
{
    public class StaticTextTranslate : MarkupExtension
    {
        public StaticTextTranslate()
        {
        }

        public StaticTextTranslate(string textToTranslate)
        {
            TextToTranslate = textToTranslate;
        }

        public string TextToTranslate { get; set; }

        public IValueConverter Converter { get; set; }

        public object ConverterParameter { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Converter != null)
            {
                return Converter.Convert(TextToTranslate, typeof(string), ConverterParameter, CultureInfo.CurrentUICulture);
            }
            return TextToTranslate;
        }
    }
}
