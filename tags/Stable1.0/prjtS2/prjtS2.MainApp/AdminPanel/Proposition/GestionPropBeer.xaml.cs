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
    /// Logique d'interaction pour GestionPropBeer.xaml
    /// </summary>
    public partial class GestionPropBeer : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        Managing.Manager Mng => Managing.Manager.Instance;

        /// <summary>
        /// List containing all the product shown 
        /// </summary>
        public List<string> Lib => Library.PROP_BIERES.Keys.ToList();


        public GestionPropBeer()
        {
            InitializeComponent();
            Mng.EventHub.PropBeerDicChanged += ListChanged;
        }

        /// <summary>
        /// Called when EventHub send a PropBeerChanged
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
