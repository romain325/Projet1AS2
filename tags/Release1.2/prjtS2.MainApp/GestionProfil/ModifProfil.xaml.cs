using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using prjtS2.FunctLibrary.Event;
using prjtS2.FunctLibrary.Ressources;

namespace prjtS2.MainApp
{
    /// <summary>
    /// Logique d'interaction pour ModifProfil.xaml
    /// </summary>
    public partial class ModifProfil : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Instance of the Manager
        /// </summary>
        readonly Managing.Manager Mng = Managing.Manager.Instance;

        /// <summary>
        /// Constructor that init the country list and subscribe to the evenement
        /// </summary>
        public ModifProfil()
        {
            InitializeComponent();
            country.ItemsSource = Ressource.Parameter.CountryArrays.Values;
            Mng.CoHandl.UserConnected += RecieveProfilInfo;
        }


        private FunctLibrary.Compte.Profil user = null;      
        /// <summary>
        /// Return the private value of user and update when a new version is setted
        /// </summary>
        public FunctLibrary.Compte.Profil User
        {
            get => user;
            private set
            {
                user = value;
                OnPropertyChanged();
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Get Profil informations and update page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void RecieveProfilInfo(object sender, ProfilEventArgs args)
        {
            User = args.User;
            if (Mng.CoHandl.User.imperatifs.Count != 0)
            {
                if (Mng.CoHandl.User.HasAlcool)
                {
                    alcool.IsChecked = true;
                }
                if (Mng.CoHandl.User.HasGluten)
                {
                    gluten.IsChecked = true;
                }
                if (Mng.CoHandl.User.HasLevure)
                {
                    levure.IsChecked = true;
                }
            }

            country.SelectedItem = Ressource.Parameter.CountryArrays[User.Localisation.Key];


        }

        /// <summary>
        /// Save all data on Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try {
                Mng.CoHandl.User.Nom = nom.Text;
                Mng.CoHandl.User.Prenom = prenom.Text;
                if (!mail.Text.Contains("@")) { throw new Exception("The mail has to contain a @"); }
                Mng.CoHandl.User.Mail = mail.Text;
                Mng.CoHandl.User.Biographie = bio.Text;
                Mng.CoHandl.User.Localisation = new Localisation((Ressource.Parameter.CountryArrays.FirstOrDefault(f => f.Value == country.SelectedItem.ToString())).Key);

                Mng.CoHandl.User.imperatifs.Clear();
                foreach (CheckBox c in allerg.Children)
                {
                    if (c.IsChecked ?? false)
                    {
                        if (c.Name == "alcool")
                        {
                            Mng.CoHandl.User.imperatifs.Add(Allergene.ALCOOL);
                        }
                        if (c.Name == "levure")
                        {
                            Mng.CoHandl.User.imperatifs.Add(Allergene.LEVURE);
                        }
                        if (c.Name == "gluten")
                        {
                            Mng.CoHandl.User.imperatifs.Add(Allergene.GLUTEN);
                        }
                    }
                }
                Mng.DataManager.ProfilData.UpdateOneFromFile(Mng.CoHandl.User.Username, Mng.CoHandl.User);

                MessageBox.Show("Toutes vos informations ont bien étés sauvegardés");
            } catch(Exception except)
            {
                MessageBox.Show("Nous faisons face à une erreur, vos données n'ont pas été sauvegardés: \n" + except.Message);
            }
            finally
            {
                Mng.Navigation.NavigateTo("profil");
            }
        }


        /// <summary>
        /// Change Profil Image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPersoImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".png",
                Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|AllTypes|*"
            };

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                string destFile = "data/img/profil/" + Mng.CoHandl.User.Username + ".png";
                System.IO.File.Copy(filename,destFile , true);
                Mng.CoHandl.User.Image = destFile;
                Mng.DataManager.ProfilData.UpdateOneFromFile(Mng.CoHandl.User.Username, Mng.CoHandl.User);
            }
            
        }
    }
}
