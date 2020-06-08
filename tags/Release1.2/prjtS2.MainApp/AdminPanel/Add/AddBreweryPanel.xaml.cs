using prjtS2.FunctLibrary.Ressources;
using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace prjtS2.MainApp.AdminPanel
{
    /// <summary>
    /// Logique d'interaction pour AddBreweryPanel.xaml
    /// </summary>
    public partial class AddBreweryPanel : UserControl , INotifyPropertyChanged
    {
        public int _Progress;

        public AddBreweryPanel()
        {
            InitializeComponent();
            country.ItemsSource = Ressource.Parameter.CountryArrays.Values;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Progress Bar value
        /// </summary>
        public int Progress
        {
            get => _Progress;
            set
            {
                if (_Progress + 1 >= 100)
                {
                    FileFinished();
                }
                _Progress += value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        Managing.Manager Mng => Managing.Manager.Instance;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Append when all the downloads are done
        /// </summary>
        private void FileFinished()
        {
            prog.Text = "Finished!!";
            bar.Value = 100;
        }

        void ReinitDefaultValue()
        {
            title.Text = "";
            content.Text = "";
            img.Text = "";
            img2.Text = "";
            img3.Text = "";

            country.SelectedIndex = -1;

            bar.Visibility = Visibility.Hidden;
            bar.Value = 0;
            prog.Text = "";
        }

        /// <summary>
        /// Download Status Changed, Set the Progress bar value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void StatusChanged(object sender, DownloadProgressChangedEventArgs args)
        {
            Progress = args.ProgressPercentage / 3;
        }

        /// <summary>
        /// Interaction logique for the Submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valide_Click(object sender, RoutedEventArgs e)
        {
            string Imag1;
            string Imag2;
            string Imag3;
            if (FunctLibrary.Library.DICO_BRASSERIES.ContainsKey(title.Text.ToLower())) { MessageBox.Show("Une Brasserie possedant le meme titre existe deja"); return; }

            if (country.SelectedIndex == -1) { MessageBox.Show("Vous devez sélectionner un pays !");return; }
            
            ///Check if the img val is empty, if so default image, else check and download it
            if (img.Text == "" || img.Text is null)
            {
                Imag1 = "data/logo.png";
                Progress = 100;
            }
            else if (FunctLibrary.Tools.WebRequest.InternetInteraction.CheckLinkIsJpgOrPng(img.Text))
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadProgressChanged += StatusChanged;
                    client.DownloadFileAsync(new Uri(img.Text), "data/img/brasserie/" + title.Text.ToLower() + "1.png");
                }
                prog.Visibility = Visibility.Visible;
                bar.Visibility = Visibility.Visible;
                Imag1 = "data/img/brasserie/" + title.Text.ToLower() + "1.png";
            }
            else { MessageBox.Show("Le lien donné n'est pas valable ! Rien n'a été enregistré. . ."); return; }


            if (img2.Text == "" || img2.Text is null)
            {
                Imag2 = "data/logo.png";
                Progress = 100;
            }
            else if (FunctLibrary.Tools.WebRequest.InternetInteraction.CheckLinkIsJpgOrPng(img2.Text))
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadProgressChanged += StatusChanged;
                    client.DownloadFileAsync(new Uri(img2.Text), "data/img/brasserie/" + title.Text.ToLower() + "2.png");
                }
                prog.Visibility = Visibility.Visible;
                bar.Visibility = Visibility.Visible;
                Imag2 = "data/img/brasserie/" + title.Text.ToLower() + "2.png";
            }
            else { MessageBox.Show("Le lien donné n'est pas valable ! Rien n'a été enregistré. . ."); return; }

            if (img3.Text == "" || img3.Text is null)
            {
                Imag3 = "data/logo.png";
                Progress = 100;
            }
            else if (!FunctLibrary.Tools.WebRequest.InternetInteraction.CheckLinkIsJpgOrPng(img.Text))
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadProgressChanged += StatusChanged;
                    client.DownloadFileAsync(new Uri(img.Text), "data/img/brasserie/" + title.Text.ToLower() + "3.png");
                }
                prog.Visibility = Visibility.Visible;
                bar.Visibility = Visibility.Visible;
                Imag3 = "data/img/brasserie/" + title.Text.ToLower() + "3.png";
            }
            else { MessageBox.Show("Le lien donné n'est pas valable ! Rien n'a été enregistré. . ."); return; }


            ///Create tje new Brewery

            var l = new FunctLibrary.Produit.Brasserie(title.Text, content.Text, new Localisation((Ressource.Parameter.CountryArrays.FirstOrDefault(f => f.Value == country.SelectedItem.ToString())).Key),
                Imag1,Imag2,Imag3);
                
            ///Save Changes to file and Initiate a BRewery Dictionary change
            Mng.DataManager.ProduitDataMng.BreweryData.AddOneToFile(l);
            Mng.EventHub.OnBreweryDicChanged(this);

            ReinitDefaultValue();
            MessageBox.Show("Votre brasserie a bien été ajouté");

            Mng.Navigation.NavigateTo("adminPanel");



        }
    }
}
