using prjtS2.FunctLibrary.DetailBiere;
using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace prjtS2.MainApp.AdminPanel
{
    /// <summary>
    /// Logique d'interaction pour AddBeerPanel.xaml
    /// </summary>
    public partial class AddBeerPanel : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        Managing.Manager Mng => Managing.Manager.Instance;
        public AddBeerPanel()
        {
            InitializeComponent();
            InitItemSource();
            Mng.EventHub.RessourceDicsChanged += OnRessourceChanged;

        }


        /// <summary>
        /// New beer Styles
        /// </summary>
        public List<FunctLibrary.Ressources.Style> Styles { get; } = new List<FunctLibrary.Ressources.Style>();

        /// <summary>
        /// New beer Cereales
        /// </summary>
        public List<Cereale> Cereales { get; } = new List<Cereale>();

        /// <summary>
        /// New beer Type
        /// </summary>
        public List<TypeBiere> TypesB { get; } = new List<TypeBiere>();

        /// <summary>
        /// New beer Specificities
        /// </summary>
        public List<Specificite> Specs { get; } = new List<Specificite>();

        /// <summary>
        /// New beer Taste
        /// </summary>
        public List<Arome> Aromes { get; } = new List<Arome>();

        /// <summary>
        /// Inititate all the ComboBox ItemsSource
        /// </summary>
        void InitItemSource()
        {
            couleur.ItemsSource = Ressource.Parameter.DICO_COULEURS.Keys;
            styles.ItemsSource = Ressource.Parameter.DICO_STYLE.Keys;
            cereales.ItemsSource = Ressource.Parameter.DICO_CEREALES.Keys;
            types.ItemsSource = Ressource.Parameter.DICO_TYPE.Keys;
            spec.ItemsSource = Ressource.Parameter.DICO_SPEC.Keys;
            aromes.ItemsSource = Ressource.Parameter.DICO_AROMES.Keys;
            brass.ItemsSource = FunctLibrary.Library.DICO_BRASSERIES.Keys;
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
            if (FunctLibrary.Library.DICO_BIERES.ContainsKey(title.Text.ToLower())) { MessageBox.Show("Une Biere possedant le meme titre existe deja"); return; }

            prog.Visibility = Visibility.Visible;
            bar.Visibility = Visibility.Visible;


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
                    client.DownloadFileAsync(new Uri(img.Text), "data/img/biere/" + title.Text.ToLower() + "1.png");
                }
                Imag1 = "data/img/biere/" + title.Text.ToLower() + "1.png";
            }
            else { MessageBox.Show("Le lien 1 donné n'est pas valable ! Rien n'a été enregistré. . ."); return; }

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
                    client.DownloadFileAsync(new Uri(img2.Text), "data/img/biere/" + title.Text.ToLower() + "2.png");
                }
                Imag2 = "data/img/biere/" + title.Text.ToLower() + "2.png";
            }
            else { MessageBox.Show("Le lien 2 donné n'est pas valable ! Rien n'a été enregistré. . ."); return; }

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
                    client.DownloadFileAsync(new Uri(img.Text), "data/img/biere/" + title.Text.ToLower() + "3.png");
                }
                Imag3 = "data/img/biere/" + title.Text.ToLower() + "3.png";
            }
            else { MessageBox.Show("Le lien 3 donné n'est pas valable ! Rien n'a été enregistré. . ."); return; }


            ///Create the new beer with the given parameter
            var l = new FunctLibrary.Produit.Biere(title.Text, content.Text,float.Parse(degree.Text, System.Globalization.CultureInfo.InvariantCulture),
                float.Parse(prix.Text,System.Globalization.CultureInfo.InvariantCulture), brass.SelectedItem.ToString(),
                new Apparence(
                    new Couleur(couleur.SelectedItem.ToString()),
                    Styles
                    ),
                new Gout(
                    Cereales,
                    TypesB,
                    Specs,
                    Aromes
                    ),
                Imag1, Imag2, Imag3,
                alcool.IsChecked.Value,
                levure.IsChecked.Value,
                gluten.IsChecked.Value
                );

            ///Add this Data to file and inform the EventHub
            Mng.DataManager.ProduitDataMng.BeerData.AddOneToFile(l);
            Mng.EventHub.OnBeerDicChanged(this);
            Mng.EventHub.OnPropBeerDicChanged(this);
            Mng.Navigation.NavigateTo("adminPanel");

        }


        public int _Progress;

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
                    _Progress = 0;
                    FileFinished();
                }
                _Progress += value;
                OnPropertyChanged();
            }
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
        /// Append when all the downloads are done
        /// </summary>
        private void FileFinished()
        {
            prog.Text = "Finished!!";
            bar.Value = 100;
        }

        /// <summary>
        /// If the EvntHub adivse of a RessourceChanged, ReInit the ItemsSources
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRessourceChanged(object sender, EventArgs e)
        {
            InitItemSource();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Add the selected value to the list of values of the new Beer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch((sender as Button).Name)
            {
                case "stylesBtn":
                    Styles.Add(new FunctLibrary.Ressources.Style(styles.SelectedItem.ToString()));
                    OnPropertyChanged(nameof(Styles));
                    break;
                case "cerealeBtn":
                    Cereales.Add(new FunctLibrary.Ressources.Cereale(cereales.SelectedItem.ToString()));
                    OnPropertyChanged(nameof(Cereales));
                    break;
                case "typesBtn":
                    TypesB.Add(new FunctLibrary.Ressources.TypeBiere(types.SelectedItem.ToString()));
                    OnPropertyChanged(nameof(TypesB));
                    break;
                case "specsBtn":
                    Specs.Add(new FunctLibrary.Ressources.Specificite(spec.SelectedItem.ToString()));
                    OnPropertyChanged(nameof(Specs));
                    break;
                case "aromesBtn":
                    Aromes.Add(new FunctLibrary.Ressources.Arome(aromes.SelectedItem.ToString()));
                    OnPropertyChanged(nameof(Aromes));
                    break;
            }
        }
    }
}
