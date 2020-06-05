using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour elemDecouverte.xaml
    /// </summary>
    public partial class ElemDecouverte : UserControl
    {
        public ElemDecouverte()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Decouverte of type Decouverte
        /// </summary>
        public static readonly DependencyProperty DecouverteDep = DependencyProperty.Register("Decouverte", typeof(FunctLibrary.Decouverte), typeof(ElemDecouverte));

        /// <summary>
        /// Decouverte from the Dependency Property
        /// </summary>
        public FunctLibrary.Decouverte Decouverte
        {
            get
            {
                return GetValue(DecouverteDep) as FunctLibrary.Decouverte;
            }
            set
            {
                SetValue(DecouverteDep, value);
            }
        }

    }
}
