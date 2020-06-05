using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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
    /// Logique d'interaction pour AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : UserControl
    {
        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        Managing.Manager Mng => Managing.Manager.Instance;
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void NewRessource_Click(object sender, RoutedEventArgs e)
        {
            Mng.Navigation.NavigateTo("addRessource");
        }

        private void NewBeer_Click(object sender, RoutedEventArgs e)
        {
            Mng.Navigation.NavigateTo("addBeer");
        }

        private void NewBrewery_Click(object sender, RoutedEventArgs e)
        {
            Mng.Navigation.NavigateTo("addBrew");
        }

        private void NewBeerProp_Click(object sender, RoutedEventArgs e)
        {
            Mng.Navigation.NavigateTo("gestPropBeer");
        }

        private void NewLesson_Click(object sender, RoutedEventArgs e)
        {
            Mng.Navigation.NavigateTo("addLesson");
        }

        private void RemoveBeer_Click(object sender, RoutedEventArgs e)
        {
            Mng.Navigation.NavigateTo("removeBeer");
        }

        private void RemoveBrewery_Click(object sender, RoutedEventArgs e)
        {
            Mng.Navigation.NavigateTo("removeBrew");
        }

        private void NewBreweryProp_Click(object sender, RoutedEventArgs e)
        {
            Mng.Navigation.NavigateTo("gestPropBrew");
        }

        private void RemoveLesson_Click(object sender, RoutedEventArgs e)
        {
            Mng.Navigation.NavigateTo("removeLesson");
        }

        /// <summary>
        /// Used to save all the data Folder into a ZIP and so you can work with your data 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveDataToZip_Click(object sender, RoutedEventArgs e)
        {
            string saveZone = "";
            var filesToSave = Directory.GetCurrentDirectory() + "/data";

            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                saveZone = dialog.SelectedPath;
            }
            saveZone += @"\BeerAppDataBackup.zip";

            if (File.Exists(saveZone))
            {
                File.Delete(saveZone);
            }
            ZipFile.CreateFromDirectory(filesToSave, saveZone);

            MessageBox.Show("BackUp Réussi");
        }
    }
}
