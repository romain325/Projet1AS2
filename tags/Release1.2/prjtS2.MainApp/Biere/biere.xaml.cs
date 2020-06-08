using prjtS2.FunctLibrary;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace prjtS2.MainApp
{
    /// <summary>
    /// Logique d'interaction pour Biere.xaml
    /// </summary>
    public partial class Biere : UserControl , INotifyPropertyChanged
    {
        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        public Managing.Manager Mng => Managing.Manager.Instance;

        public Biere()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Beer Dependency Property, Name of the beer to print out , has to be lower case
        /// </summary>
        public static readonly DependencyProperty BeerNameProperty = DependencyProperty.Register("BeerPropName", typeof(string), typeof(Biere),
            new PropertyMetadata(null, new PropertyChangedCallback(OnDepPropChanged)));

        /// <summary>
        /// Beer property name
        /// </summary>
        public string BeerPropName
        {
            get
            {
                return GetValue(BeerNameProperty) as string;
            }
            set
            {
                SetValue(BeerNameProperty, value);
            }
        }

        /// <summary>
        /// Beer value calculated from beer Prop Name
        /// </summary>
        public FunctLibrary.Produit.Biere BeerVal
        {
            get
            {
                if (BeerPropName != null)
                {
                    return Library.DICO_BIERES[BeerPropName];
                }
                else { return null; }
            }
        }

        /// <summary>
        /// Calculate BeerVal when DepProperty Change
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnDepPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Biere b = d as Biere;
            b.OnPropertyChanged(nameof(BeerVal));
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Permits to give a mark to a beer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoteProduit(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Mng.CoHandl.IsConnected) { throw new Exception("Vous devez vous connecter avant de pouvoir voter!"); }
                Library.DICO_BIERES[BeerPropName].Note = Convert.ToInt32(PersonalMark.Text);
                OnPropertyChanged(nameof(BeerVal));
                MessageBox.Show("Votre Note a bien été prise en compte!:" + Library.DICO_BIERES[BeerPropName].Note);
            }
            catch (Exception exc)
            {
                MessageBox.Show("La valeur indiqué n'est pas bonne !\n" + exc.Message);
            }
        }

        /// <summary>
        /// Add this beer to the User's favorites
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fav_Click(object sender, RoutedEventArgs e)
        {
            if(Mng.CoHandl.User == null)
            {
                MessageBox.Show("Vous devez être connecté pour ajouter un produit à vos favoris");
                return;
            }

            if (Mng.CoHandl.User.Favoris.Contains(Library.DICO_BIERES[BeerPropName]))
            {
                Mng.CoHandl.User.Favoris.Remove(Library.DICO_BIERES[BeerPropName]);
                Mng.DataManager.ProfilData.UpdateOneFromFile(Mng.CoHandl.User.Username, Mng.CoHandl.User);
                MessageBox.Show("Cette bière a bien été retiré de vos favoris");
            }
            else
            {
                Mng.CoHandl.User.Favoris.Add(Library.DICO_BIERES[BeerPropName]);
                Mng.DataManager.ProfilData.UpdateOneFromFile(Mng.CoHandl.User.Username, Mng.CoHandl.User);
                MessageBox.Show("Cette bière a bien été ajouté à vos favoris");
            }
        }
    }
}
