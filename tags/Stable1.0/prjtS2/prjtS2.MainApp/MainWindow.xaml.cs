using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace prjtS2.MainApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitNavigationSystem();
            DataContext = this;          
        }

        void InitNavigationSystem()
        {
            ///Binding operation to get the UserControls shown up as content
            Binding bind = new Binding();
            bind.Source = Mng.Navigation;
            bind.Mode = BindingMode.TwoWay;
            bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            bind.Path = new PropertyPath("SelectedUserControl");
            BindingOperations.SetBinding(contentControl, ContentControl.ContentProperty, bind);

            ///Different UserControls that can be called from the MW in the Main ContentControl
            Mng.Navigation.userControls.Add("decouverte", new Decouverte());

            Mng.Navigation.userControls.Add("rechBiere",new RechercheBiere());
            Mng.Navigation.userControls.Add("rechBrasserie", new RechBrasserie());

            Mng.Navigation.userControls.Add("lecons", new HubLecon());

            Mng.Navigation.userControls.Add("connexion", new Connexion());
            Mng.Navigation.userControls.Add("creaProfil1", new NouveauCompte());
            Mng.Navigation.userControls.Add("creaProfil2", new CreaCompteConnaisseur());
            Mng.Navigation.userControls.Add("profil", new Profil());
            Mng.Navigation.userControls.Add("modifProfil", new ModifProfil());

            Mng.Navigation.userControls.Add("adminPanel", new AdminPanel.AdminPanel());
            Mng.Navigation.userControls.Add("addRessource", new AdminPanel.AddRessourcePanel());
            Mng.Navigation.userControls.Add("addLesson", new AdminPanel.AddLessonPanel());
            Mng.Navigation.userControls.Add("addBrew", new AdminPanel.AddBreweryPanel());
            Mng.Navigation.userControls.Add("addBeer", new AdminPanel.AddBeerPanel());
            Mng.Navigation.userControls.Add("removeBeer", new AdminPanel.RemoveBeer());
            Mng.Navigation.userControls.Add("removeBrew", new AdminPanel.RemoveBrewery());
            Mng.Navigation.userControls.Add("removeLesson", new AdminPanel.RemoveLesson());
            Mng.Navigation.userControls.Add("gestPropBeer", new AdminPanel.GestionPropBeer());
            Mng.Navigation.userControls.Add("gestPropBrew", new AdminPanel.GestionPropBrew());

            Mng.Navigation.userControls.Add("launch", new LaunchAdult());

            ///Start up the control to check if the User is 18 or more
            Mng.Navigation.NavigateTo("launch");

        }

        /// <summary>
        /// Manager Instance
        /// </summary>
        public Managing.Manager Mng = Managing.Manager.Instance;

        public void rechBiereClick(object sender, RoutedEventArgs e)
        {
            if (Mng.CoHandl.Is18)
            {
                Mng.Navigation.NavigateTo("rechBiere");
            }
        }

        public void rechBrasserieClick(object sender, RoutedEventArgs e)
        {
            if (Mng.CoHandl.Is18)
            {
                Mng.Navigation.NavigateTo("rechBrasserie");
            }
        }

        public void leconsClick(object sender, RoutedEventArgs e)
        {
            if (Mng.CoHandl.Is18)
            {
                Mng.Navigation.NavigateTo("lecons");
            }
        }

        public void decouverteClick(object sender, RoutedEventArgs e)
        {
            if (Mng.CoHandl.Is18)
            {
                Mng.Navigation.NavigateTo("decouverte");
            }

        }

        public void profilClick(object sender, RoutedEventArgs e)
        {
            if (Mng.CoHandl.Is18)
            {
                if (Mng.CoHandl.IsConnected)
                {
                    Mng.Navigation.NavigateTo("profil");

                }
                else
                {
                    Mng.Navigation.NavigateTo("connexion");
                }
               
            }
        }

    }
}
