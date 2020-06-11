using prjtS2.FunctLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prjtS2.MainApp
{
    /// <summary>
    /// Logique d'interaction pour lecon.xaml
    /// </summary>
    public partial class Lecon : UserControl, INotifyPropertyChanged
    {
        public Lecon()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lecon dependency property
        /// </summary>
        public static readonly DependencyProperty LeconNameProperty = DependencyProperty.Register("LeconPropName", typeof(string), typeof(Lecon),
            new PropertyMetadata(null, new PropertyChangedCallback(OnDepPropChanged)));

        
        /// <summary>
        /// Lecon Name
        /// </summary>
        public string LeconPropName
        {
            get
            {
                return GetValue(LeconNameProperty) as string;
            }
            set
            {
                SetValue(LeconNameProperty, value);
            }
        }

        /// <summary>
        /// Lecon val from name
        /// </summary>
        public FunctLibrary.Lecon LeconVal
        {
            get
            {
                if(LeconPropName != null)
                {
                    return Library.LECON[LeconPropName];
                }
                else { return null; }
            }
        }

        private static void OnDepPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Lecon b = d as Lecon;
            b.OnPropertyChanged(nameof(LeconVal));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
