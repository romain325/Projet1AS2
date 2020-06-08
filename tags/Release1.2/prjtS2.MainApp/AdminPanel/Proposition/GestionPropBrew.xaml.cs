using prjtS2.FunctLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace prjtS2.MainApp.AdminPanel
{
    /// <summary>
    /// Logique d'interaction pour GestionPropBrew.xaml
    /// </summary>
    public partial class GestionPropBrew : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        Managing.Manager Mng => Managing.Manager.Instance;
        
        /// <summary>
        /// List containing all the product shown 
        /// </summary>
        public List<string> Lib => Library.PROP_BRASSERIES.Keys.ToList();

        public GestionPropBrew()
        {
            InitializeComponent();
            Mng.EventHub.PropBrewDicChanged += ListChanged;
        }

        /// <summary>
        /// Called when EventHub send a BeerChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListChanged(object sender, EventArgs e)
        {
            lb.SelectedItem = 0;
            OnPropertyChanged(nameof(Lib));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
