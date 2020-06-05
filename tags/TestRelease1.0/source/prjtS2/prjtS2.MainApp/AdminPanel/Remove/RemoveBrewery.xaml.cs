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
    /// Logique d'interaction pour RemoveBrewery.xaml
    /// </summary>
    public partial class RemoveBrewery : UserControl, INotifyPropertyChanged
    {
        public RemoveBrewery()
        {
            InitializeComponent();
            Mng.EventHub.BreweryDicChanged += OnBrewRemoved;
        }

        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        Managing.Manager Mng => Managing.Manager.Instance;

        /// <summary>
        /// Called when EventHub send a BrewChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBrewRemoved(object sender, EventArgs e)
        {
            lb.SelectedIndex = 0;
            OnPropertyChanged(nameof(Lib));
        }


        /// <summary>
        /// Command Class used to remove a Brewery
        /// </summary>
        RemoveBrewCommand RemoveIt = new RemoveBrewCommand();

        /// <summary>
        /// The command used itself
        /// </summary>
        public ICommand Command => RemoveIt.RemoveIt;

        /// <summary>
        /// List of brewery that can be removed
        /// </summary>
        public List<string> Lib => Library.DICO_BRASSERIES.Keys.ToList();



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
