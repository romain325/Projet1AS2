using prjtS2.FunctLibrary.Ressources;
using prjtS2.MainApp.Tools.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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
    /// Logique d'interaction pour AddRessourcePanel.xaml
    /// </summary>
    public partial class AddRessourcePanel : UserControl , System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Command used to create a new Ressource
        /// </summary>
        AddRessourceCommand SaveCommand = new prjtS2.MainApp.Tools.Command.AddRessourceCommand();


        public AddRessourcePanel()
        {
            InitializeComponent();
            InitDictionary();
            OnPropertyChanged();
        }

        /// <summary>
        /// Init the dictionary containing the SaveCommand and the different Types of Ressources
        /// </summary>
        void InitDictionary()
        {
            keyValuePairs.Add("Types Bieres", SaveCommand.SaveRessource);
            keyValuePairs.Add("Aromes", SaveCommand.SaveRessource);
            keyValuePairs.Add("Cereales", SaveCommand.SaveRessource);
            keyValuePairs.Add("Couleur", SaveCommand.SaveRessource);
            keyValuePairs.Add("Specificite", SaveCommand.SaveRessource);
            keyValuePairs.Add("Style", SaveCommand.SaveRessource);
        }

        /// <summary>
        /// Dictionary containing Ressources name (used in command with MultiBinding)
        /// </summary>
        public Dictionary<string, ICommand> keyValuePairs { get; } = new Dictionary<string, ICommand>();

        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
