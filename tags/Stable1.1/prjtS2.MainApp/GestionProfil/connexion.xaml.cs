using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace prjtS2.MainApp
{
    /// <summary>
    /// Logique d'interaction pour connexion.xaml
    /// </summary>
    public partial class Connexion : UserControl
    {
        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        public Managing.Manager Mng = Managing.Manager.Instance;

        public Connexion()
        {
            InitializeComponent();
            this.KeyDown += Connexion_TouchDown;
        }

        /// <summary>
        /// If Enter is pressed, launch COnnection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Connexion_TouchDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                connexion();
            }
        }

        /// <summary>
        /// On click connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connect_Click(object sender, RoutedEventArgs e)
        {
            connexion();
        }

        /// <summary>
        /// Move to the creation profil page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void creaCompte_Click(object sender, RoutedEventArgs e)
        {
            Mng.Navigation.NavigateTo("creaProfil1");
        }

        /// <summary>
        /// try to connect 
        /// </summary>
        private void connexion()
        {
            try
            {
                Mng.CoHandl.Connexion(this.username.Text, this.password.Password.ToString());
                Mng.Navigation.NavigateTo("profil");
            }
            catch
            {
                MessageBox.Show("Malheureusement ce UserName n'est pas relié à un compte");
                Mng.Navigation.NavigateTo("connexion");
            }
        }
    }
}
