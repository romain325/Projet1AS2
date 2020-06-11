using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.Compte;
using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logique d'interaction pour nouveauCompte.xaml
    /// </summary>
    public partial class NouveauCompte : UserControl
    {
        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        readonly Managing.Manager Mng = Managing.Manager.Instance;
        public NouveauCompte()
        {
            InitializeComponent();
            country.ItemsSource = Ressource.Parameter.CountryArrays.Values;
            
        }

        /// <summary>
        /// Continue the creation of the profil by adding not indispensable values to it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void continueCrea_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                FunctLibrary.Compte.Profil profil = new FunctLibrary.Compte.Profil(username.Text, nom.Text, prenom.Text, password.Password.ToString(), mail.Text, new DateTime(dobirth.SelectedDate.Value.Ticks),
                    new Localisation(Ressource.Parameter.CountryArrays.First(f=> f.Value == country.SelectedItem.ToString() ).Key), "Vous n'avez pas encore de description","data/logo.png" ,false);
                
                Mng.DataManager.ProfilData.AddOneToFile(profil);
                Mng.CoHandl.Connexion(username.Text, password.Password.ToString());
                
                Mng.Navigation.NavigateTo("creaProfil2");
            }catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            } 
        }
    }
}
