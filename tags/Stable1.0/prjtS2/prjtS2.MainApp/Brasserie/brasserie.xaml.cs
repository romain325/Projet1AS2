using prjtS2.FunctLibrary;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
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
    /// Logique d'interaction pour brasserie.xaml
    /// </summary>
    public partial class Brasserie : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        public Managing.Manager Mng => Managing.Manager.Instance;
        public Brasserie()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Brewery Dependency Property
        /// </summary>
        public static readonly DependencyProperty BreweryNameProperty = DependencyProperty.Register("BreweryPropName", typeof(string), typeof(Brasserie),
            new PropertyMetadata(null, new PropertyChangedCallback(OnDepPropChanged)));

        /// <summary>
        /// Brewery Name
        /// </summary>
        public string BreweryPropName
        {
            get
            {
                return GetValue(BreweryNameProperty) as string;
            }
            set
            {
                SetValue(BreweryNameProperty, value);
            }
        }

        /// <summary>
        /// Brewery val caluclated from Brewery Name
        /// </summary>
        public FunctLibrary.Produit.Brasserie BreweryVal
        {
            get
            {
                if (BreweryPropName != null)
                {
                    return Library.DICO_BRASSERIES[BreweryPropName];
                }
                else { return null; }
            }
        }

        private static void OnDepPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Brasserie b = d as Brasserie;
            b.OnPropertyChanged(nameof(BreweryVal));
            b.lb.ItemsSource = b.BreweryVal.Bieres;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Give a Mark to the Brewery
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoteProduit(object sender, RoutedEventArgs e)
        {
            try {
                if (!Mng.CoHandl.IsConnected) { throw new Exception("Vous devez vous connecter avant de pouvoir voter!"); }
                Library.DICO_BRASSERIES[BreweryPropName].Note = Convert.ToInt32(PersonalMark.Text);
                OnPropertyChanged(nameof(BreweryVal));
                MessageBox.Show("Votre Note a bien été prise en compte!:" + Library.DICO_BRASSERIES[BreweryPropName].Note );
            } catch(Exception exc)
            {
                MessageBox.Show("La valeur indiqué n'est pas bonne !\n"+ exc.Message);
            }
            MessageBox.Show(new FunctLibrary.Tools.CollectionToString().ACollectionToString(BreweryVal.Bieres));
        }

    }
}
