using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.Event;
using prjtS2.FunctLibrary.Ressources;
using prjtS2.MainApp.Tools;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace prjtS2.MainApp
{
    /// <summary>
    /// Logique d'interaction pour RechercheBiere.xaml
    /// </summary>
    public partial class RechercheBiere : UserControl , INotifyPropertyChanged
    {
        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        public Managing.Manager Mng => Managing.Manager.Instance;

        private bool showDetails = false;

        /// <summary>
        /// Search Tool
        /// </summary>
        readonly GetSearchMatch SearchTool = new GetSearchMatch();

        public RechercheBiere()
        {
            InitializeComponent();
            InitItemSource();
            OrderBy.ItemsSource = EnumTransformation.GetDescriptionFromValueList<OrderType>();
            OrderBy.SelectedIndex = 0;
            InitInteracChanged();
            Mng.CoHandl.UserConnected += ProfilConnectedChanged;
            Mng.EventHub.BeerDicChanged += OnBeerChanged;
            Mng.EventHub.BreweryDicChanged += OnRessourceChanged;
            Mng.EventHub.RessourceDicsChanged += OnRessourceChanged;
            OnPropertyChanged(nameof(Lib));
        }

        private byte selectedDegree;
        private byte selectedPrice;

        /// <summary>
        /// List showed in the Beer Search Interfaces, Send data to the SearchTool and get an ObservableCollection back
        /// </summary>
        public ObservableCollection<string> Lib => SearchTool.GetBiereSearchResult(Search, country.SelectedItem,
                    couleur.SelectedItem, arome.SelectedItem, spec.SelectedItem,
                    cereale.SelectedItem, typeBiere.SelectedItem, brasserie.SelectedItem,
                    selectedDegree, selectedPrice, EnumTransformation.GetValueFromIndex<OrderType>(OrderBy.SelectedIndex));

        /// <summary>
        /// Init all the Interaction change event that we have to track
        /// </summary>
        void InitInteracChanged()
        {
            country.SelectionChanged += OnParameterChanged;
            couleur.SelectionChanged += OnParameterChanged;
            arome.SelectionChanged += OnParameterChanged;
            spec.SelectionChanged += OnParameterChanged;
            cereale.SelectionChanged += OnParameterChanged;
            typeBiere.SelectionChanged += OnParameterChanged;
            brasserie.SelectionChanged += OnParameterChanged;
            OrderBy.SelectionChanged += OnParameterChanged;
            foreach (RadioButton i in degree.Children)
            {
                i.Checked += OnChangeDegreeChecked;
            }

            foreach (RadioButton i in prix.Children)
            {
                i.Checked += OnChangePrixChecked;
            }
        }

        /// <summary>
        /// Init all the ComboBox ItemSources
        /// </summary>
        void InitItemSource()
        {
            country.ItemsSource = Ressource.Parameter.CountryArrays.Values;
            country.SelectedItem = "Non Indiqué";

            couleur.ItemsSource =  Ressource.Parameter.DICO_COULEURS.Values;
            couleur.SelectedItem = "Aucune Préference";

            arome.ItemsSource = Ressource.Parameter.DICO_AROMES.Values;
            arome.SelectedItem = "Aucune Préference";

            spec.ItemsSource = Ressource.Parameter.DICO_SPEC.Values;
            spec.SelectedItem = "Aucune Préference";

            cereale.ItemsSource = Ressource.Parameter.DICO_CEREALES.Values;
            cereale.SelectedItem = "Aucune Préference";

            typeBiere.ItemsSource = Ressource.Parameter.DICO_TYPE.Values;
            typeBiere.SelectedItem = "Aucune Préference";

            brasserie.ItemsSource = Library.DICO_BRASSERIES.Keys;
        }

        private string Search { get; set; }
        /// <summary>
        /// TextBox Value --> Search
        /// </summary>
        public string TextBoxVal
        {
            get => Search;
            set
            {
                Search = value;
                OnPropertyChanged(nameof(Lib));
            }
        }

        /// <summary>
        /// Interaction logique to show or hide Details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moreDetails(object sender, RoutedEventArgs e)
        {
            if (!showDetails)
            {
                details.Height = new GridLength(2.5,GridUnitType.Star);
                moreButton.Content = "-";
                showDetails = true;
            }
            else
            {
                details.Height = new GridLength(0,GridUnitType.Star);
                moreButton.Content = "+";
                showDetails = false;
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Track if a user is connected to take in count his Parameter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void ProfilConnectedChanged(object sender, ProfilEventArgs args)
        {
            Mng.CoHandl.User.UserChanged += ProfilInfoChanged;
        }

        /// <summary>
        /// Recaluclate Search Result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void ProfilInfoChanged(object sender, ProfilEventArgs args)
        {
            OnPropertyChanged(nameof(Lib));
        }

        /// <summary>
        /// Recaluclate Search Result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnParameterChanged(object sender, EventArgs args)
        {
            OnPropertyChanged(nameof(Lib));
        }

        /// <summary>
        /// Recaluclate Search Result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnBeerChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(Lib));
        }

        /// <summary>
        /// ReInit ItemSources
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnRessourceChanged(object sender, EventArgs e)
        {
            InitItemSource();
        }

        /// <summary>
        /// Track Degree changes and recaluclate Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnChangeDegreeChecked(object sender, RoutedEventArgs args)
        {
            switch((sender as RadioButton).Uid)
            {
                case "all":
                    selectedDegree = 0;
                    break;
                case "0":
                    selectedDegree = 1;
                    break;
                case "0_4":
                    selectedDegree = 2;
                    break;
                case "4_8":
                    selectedDegree = 3;
                    break;
                case "8+":
                    selectedDegree = 4;
                    break;
            }
            OnPropertyChanged(nameof(Lib));
        }

        /// <summary>
        /// Track Price changes and recaluclate Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnChangePrixChecked(object sender, RoutedEventArgs args)
        {
            switch ((sender as RadioButton).Uid)
            {
                case "all":
                    selectedPrice = 0;
                    break;
                case "-2":
                    selectedPrice = 1;
                    break;
                case "2_5":
                    selectedPrice = 2;
                    break;
                case "5_10":
                    selectedPrice = 3;
                    break;
                case "10+":
                    selectedPrice = 4;
                    break;
            }
            OnPropertyChanged(nameof(Lib));

        }
        
    }
}
