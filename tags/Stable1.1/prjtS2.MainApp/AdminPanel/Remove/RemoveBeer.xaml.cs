using prjtS2.FunctLibrary;
using prjtS2.MainApp.Tools.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace prjtS2.MainApp.AdminPanel
{
    /// <summary>
    /// Logique d'interaction pour RemoveBeer.xaml
    /// </summary>
    public partial class RemoveBeer : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Command Class used to remove a beer
        /// </summary>
        RemoveBeerCommand RemoveIt = new RemoveBeerCommand();

        public RemoveBeer()
        {
            InitializeComponent();
            Mng.EventHub.BeerDicChanged += OnBeerRemoved;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The command used itself
        /// </summary>
        public ICommand Command => RemoveIt.RemoveIt;

        /// <summary>
        /// List of beer that can be removed
        /// </summary>
        public List<string> Lib => Library.DICO_BIERES.Keys.ToList();

        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        Managing.Manager Mng => Managing.Manager.Instance;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Called when EventHub send a BeerChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBeerRemoved(object sender, EventArgs e)
        {
            lb.SelectedIndex = 0;
            OnPropertyChanged(nameof(Lib));
        }
    }
}
