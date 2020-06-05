using prjtS2.FunctLibrary;
using prjtS2.MainApp.Tools.Command;
using System;
using System.Collections.Generic;
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

namespace prjtS2.MainApp.AdminPanel
{
    /// <summary>
    /// Logique d'interaction pour RemoveLesson.xaml
    /// </summary>
    public partial class RemoveLesson : UserControl, INotifyPropertyChanged
    {
        public RemoveLesson()
        {
            InitializeComponent();
            Mng.EventHub.LessonDicChanged += OnLessonChanged;
        }

        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        Managing.Manager Mng => Managing.Manager.Instance;

        /// <summary>
        /// Called when EventHub send a BeerChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLessonChanged(object sender, EventArgs e)
        {
            lb.SelectedIndex = 0;
            OnPropertyChanged(nameof(Lib));
        }

        /// <summary>
        /// Command Class used to remove a beer
        /// </summary>
        RemoveLessonCommand RemoveIt = new RemoveLessonCommand();

        /// <summary>
        /// The command used itself
        /// </summary>
        public ICommand Command => RemoveIt.RemoveIt;

        /// <summary>
        /// List of beer that can be removed
        /// </summary>
        public List<string> Lib => Library.LECON.Keys.ToList();



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
