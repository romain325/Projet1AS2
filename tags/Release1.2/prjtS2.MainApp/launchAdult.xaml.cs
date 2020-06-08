using prjtS2.FunctLibrary;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour launchAdult.xaml
    /// </summary>
    public partial class LaunchAdult : UserControl
    {
        /// <summary>
        /// Manager Instance
        /// </summary>
        Managing.Manager Mng = Managing.Manager.Instance;

        public LaunchAdult()
        {
            InitializeComponent();
        }

        /// <summary>
        /// If the User is <18 then the App ShutDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mineur(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tu dois être majeur pour utiliser cette application", "C'est pas bien ce que tu fais la!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// If the user is 18 or more then everything goes on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isMajeur_Click(object sender, RoutedEventArgs e)
        {
            Mng.CoHandl.Is18 = true;
            Mng.Navigation.NavigateTo("rechBiere");
        }
    }
}
