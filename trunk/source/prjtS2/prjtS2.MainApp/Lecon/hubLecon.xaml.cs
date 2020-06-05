using prjtS2.FunctLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Logique d'interaction pour hubLecon.xaml
    /// </summary>
    public partial class HubLecon : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Manager Instance
        /// </summary>
        Managing.Manager Mng => Managing.Manager.Instance;

        public HubLecon()
        {
            InitializeComponent();
            Mng.EventHub.LessonDicChanged += UpdateList;
        }

        /// <summary>
        /// Binding source
        /// </summary>
        public Dictionary<string,FunctLibrary.Lecon> Lib => Library.LECON;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Triggers by EventHub, Update Lib
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void UpdateList(object sender, EventArgs args)
        {
            OnPropertyChanged(nameof(Lib));
        }
    }
}
