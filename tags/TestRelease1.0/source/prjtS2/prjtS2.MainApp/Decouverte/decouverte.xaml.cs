using prjtS2.FunctLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
    /// Logique d'interaction pour decouverte.xaml
    /// </summary>
    public partial class Decouverte : UserControl, INotifyPropertyChanged
    {
        public Decouverte()
        {
            InitializeComponent();
            AllDecouvertes.CollectionChanged += AllDecouvertes_CollectionChanged;
            OnPropertyChanged();
        }

        /// <summary>
        /// Keep track of our ObservableCollection changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllDecouvertes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(AllDecouvertes));
        }

        /// <summary>
        /// Observable Colelction containing all the Discovery Parameters
        /// Not meaned to be interactiv (we can't add more to it or remove them)
        /// So it's hard Coded
        /// </summary>
        public ObservableCollection<FunctLibrary.Decouverte> AllDecouvertes { get; } = new ObservableCollection<FunctLibrary.Decouverte>()
        {
            new FunctLibrary.Decouverte("In the Jura", Library.DICO_BIERES.Values.ToList()  , "data/logo.png"),
            new FunctLibrary.Decouverte("In the Jura", Library.DICO_BIERES.Values.ToList()  , "data/logo.png"),
            new FunctLibrary.Decouverte("In the Jura", Library.DICO_BIERES.Values.ToList()  , "data/logo.png"),
            new FunctLibrary.Decouverte("In the Jura", Library.DICO_BIERES.Values.ToList()  , "data/logo.png"),
            new FunctLibrary.Decouverte("In the Jura", Library.DICO_BIERES.Values.ToList()  , "data/logo.png"),
            new FunctLibrary.Decouverte("In the Jura", Library.DICO_BIERES.Values.ToList()  , "data/logo.png"),
        };

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
