using prjtS2.MainApp.Tools;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace prjtS2.MainApp
{
    /// <summary>
    /// Logique d'interaction pour rechBrasserie.xaml
    /// </summary>
    public partial class RechBrasserie : UserControl , INotifyPropertyChanged
    {
        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        public Managing.Manager Mng => Managing.Manager.Instance;

        /// <summary>
        /// Initiate SearchTool 
        /// </summary>
        public GetSearchMatch SeachTool = new GetSearchMatch();

        /// <summary>
        /// Library Binded from Search Tool
        /// </summary>
        public ObservableCollection<string> Lib => SeachTool.GetBrasserieSearchResult(Search);

        public RechBrasserie()
        {
            InitializeComponent();
            Mng.EventHub.BreweryDicChanged += OnBrewChanged;
            Mng.EventHub.PropBrewDicChanged += OnBrewChanged;
        }

        /// <summary>
        /// Keep track of any brewery changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBrewChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(Lib));
            OnPropertyChanged();
        }


        private string Search { get; set; }
        /// <summary>
        /// TextBox value used for search
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
