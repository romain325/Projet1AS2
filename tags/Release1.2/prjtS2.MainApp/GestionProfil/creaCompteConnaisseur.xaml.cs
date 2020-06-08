using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.Ressources;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace prjtS2.MainApp
{
    /// <summary>
    /// Logique d'interaction pour creaCompteConnaisseur.xaml
    /// </summary>
    public partial class CreaCompteConnaisseur : UserControl
    {
        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        public Managing.Manager Mng = Managing.Manager.Instance;
        public CreaCompteConnaisseur()
        {
            InitializeComponent();
            this.KeyDown += AdminShowUp;
        }

        /// <summary>
        /// Admin PassPhrase prompt appear if this combinaison of touches is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminShowUp(object sender, KeyEventArgs e)
        {
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && (e.Key == Key.LeftAlt))
            {
                ReduceMe.Height = new GridLength(0.3, GridUnitType.Star);
                IncreaseMe.Height = new GridLength(0.5, GridUnitType.Star);
            }
        }

        /// <summary>
        /// Save datas to the Connected profil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void finish_Click(object sender, RoutedEventArgs e)
        {
            //Ajoute les allergenes précisés à la liste
            foreach(CheckBox c in allerg.Children)
            {
                if (c.IsChecked??false)
                {
                    if(c.Name == "alcool")
                    {
                        Mng.CoHandl.User.imperatifs.Add(Allergene.ALCOOL);
                    }
                    if(c.Name == "levure")
                    {
                        Mng.CoHandl.User.imperatifs.Add(Allergene.LEVURE);
                    }
                    if (c.Name == "gluten")
                    {
                        Mng.CoHandl.User.imperatifs.Add(Allergene.GLUTEN);
                    }
                }
            }

            //Enregistre la description
            Mng.CoHandl.User.Biographie = desc.Text;

            //Rajoute aux favoris toutes les bières suivantes
            foreach(CheckBox c in fav.Children)
            {
                try
                {
                    if (c.IsChecked ?? false)
                    {
                        Mng.CoHandl.User.Favoris.Add(Library.DICO_BIERES[c.Name.ToLower()]);
                    }
                }catch(Exception excep)
                {
                    MessageBox.Show("Nous sommes désolés mais une erreur à eu lieu: \n" + excep.Message);
                }

            }

            //Envoi vers les lecons si non connaisseur et sinon vers la recherche
            if (connaisseur.IsChecked??false)
            {
                Mng.Navigation.NavigateTo("rechBiere");
            }
            else
            {
                Mng.Navigation.NavigateTo("lecons");
            }

            if(AdminCode.Text != null ||  AdminCode.Text != "")
            {
                using (BinaryReader br = new BinaryReader(new FileStream("data/Unsecure.bin", FileMode.Open)))
                {
                    string s = br.ReadString();
                    if (AdminCode.Text == prjtS2.FunctLibrary.Tools.Crypto.Encrypt.DecryptString(s, "SaltNVinegar"))
                    {
                        Library.ADMIN_PROFIL.Add(Mng.CoHandl.User.Username);
                        MessageBox.Show("You've successfully added to the Admin Team ^^");
                    }
                }

            }

            Mng.DataManager.ProfilData.UpdateOneFromFile(Mng.CoHandl.User.Username, Mng.CoHandl.User);
        }
    }
}
