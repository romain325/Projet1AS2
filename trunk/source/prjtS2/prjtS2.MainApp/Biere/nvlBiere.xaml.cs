using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.DetailBiere;
using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace prjtS2.MainApp
{
    /// <summary>
    /// Logique d'interaction pour NvlBiere.xaml
    /// </summary>
    public partial class NvlBiere : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// BeerVal dependency property
        /// </summary>
        public static readonly DependencyProperty BeerNameProperty = DependencyProperty.Register("BeerPropName", typeof(string), typeof(NvlBiere),
            new PropertyMetadata(null, new PropertyChangedCallback(OnDepPropChanged)));

        public int _Progress;

        public NvlBiere()
        {
            InitializeComponent();
            InitItemSource();
            Mng.EventHub.RessourceDicsChanged += OnRessourceChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Arome> Aromes { get; set; } = new List<Arome>();

        /// <summary>
        /// Beer Dep Property name
        /// </summary>
        public string BeerPropName
        {
            get
            {
                return GetValue(BeerNameProperty) as string;
            }
            set
            {
                SetValue(BeerNameProperty, value);
            }
        }


        /// <summary>
        /// Beer Prop value calculate from his name
        /// </summary>
        public FunctLibrary.Produit.PropBiere BeerVal
        {
            get
            {
                if (BeerPropName != null)
                {
                    return Library.PROP_BIERES[BeerPropName];
                }
                else { return null; }
            }
        }

        public List<Cereale> Cereales { get; set; } = new List<Cereale>();

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

        public List<Specificite> Specs { get; set; } = new List<Specificite>();

        public List<FunctLibrary.Ressources.Style> Styles { get; set; } = new List<FunctLibrary.Ressources.Style>();

        public List<TypeBiere> TypesB { get; set; } = new List<TypeBiere>();

        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        private Managing.Manager Mng => Managing.Manager.Instance;

        public void ReturnToDefaultValue()
        {
            title.Text = "";
            content.Text = "";
            degree.Text = "";
            prix.Text = "";
            img.Text = "";
            img2.Text = "";
            img3.Text = "";

            couleur.SelectedIndex = 0;
            brass.SelectedIndex = 0;

            Styles.Clear();
            Aromes.Clear();
            Specs.Clear();
            Cereales.Clear();
            TypesB.Clear();

            bar.Visibility = Visibility.Hidden;
            bar.Value = 0;
            prog.Text = "";

            OnPropertyChanged(nameof(couleur));
            OnPropertyChanged(nameof(styles));
            OnPropertyChanged(nameof(cereales));
            OnPropertyChanged(nameof(types));
            OnPropertyChanged(nameof(spec));
            OnPropertyChanged(nameof(aromes));
            OnPropertyChanged(nameof(brass));
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Interaction on Dep Property Changed, If BeerVal is null, block Submit button
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnDepPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NvlBiere b = d as NvlBiere;
            if (b.BeerVal != null)
            {
                b.Styles = b.BeerVal.Apparence.Styles;
                b.Cereales = b.BeerVal.Gout.Cereales;
                b.TypesB = b.BeerVal.Gout.Types;
                b.Specs = b.BeerVal.Gout.Specificites;
                b.Aromes = b.BeerVal.Gout.Aromes;
                b.OnPropertyChanged(nameof(Styles));
                b.OnPropertyChanged(nameof(Cereales));
                b.OnPropertyChanged(nameof(TypesB));
                b.OnPropertyChanged(nameof(Specs));
                b.OnPropertyChanged(nameof(Aromes));

                b.OnPropertyChanged(nameof(BeerVal));
            }
            else
            {
                b.valide.IsEnabled = false;
            }
        }

        /// <summary>
        /// Add PArameter to list of parameter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
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

        /// <summary>
        /// Append when all the downloads are done
        /// </summary>
        private void FileFinished()
        {
            prog.Text = "Finished!!";
            bar.Value = 100;
        }

        private void InitItemSource()
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
        /// ReInit ItemsSources when Ressources Changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRessourceChanged(object sender, EventArgs e)
        {
            InitItemSource();
        }

        /// <summary>
        /// DOwnload status actualization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void StatusChanged(object sender, DownloadProgressChangedEventArgs args)
        {
            Progress = args.ProgressPercentage / 3;
        }

        /// <summary>
        /// Submit button interaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valide_Click(object sender, RoutedEventArgs e)
        {
            ///Check for null valuess
            if (degree.Text is null || prix.Text is null || degree.Text == "" || prix.Text == "") { MessageBox.Show("Le prix / Degrees ne peut pas etre nulle!"); return; }
            if (brass.SelectedIndex == -1) { MessageBox.Show("Veuillez à selectionner une brasserie!"); return; }

            string Imag1;
            string Imag2;
            string Imag3;

            ///If we pass an Argument through Dependency Properperty
            ///     --> send by AdminPropBeerPanel --> allow definitiv adding
            ///If no Dependency Propery Parameter
            ///     --> send by BeerPropostion --> save data to Proposition
            if (BeerVal == null)
            {
                if (FunctLibrary.Library.DICO_BIERES.ContainsKey(title.Text.ToLower()) || Library.PROP_BIERES.ContainsKey(title.Text.ToLower())) { MessageBox.Show("Une Biere possedant le meme titre existe deja"); return; }

                Imag1 = img.Text;

                Imag2 = img2.Text;

                Imag3 = img3.Text;

                ///Add Instance to the proposition
                var l = new FunctLibrary.Produit.PropBiere(title.Text, content.Text, float.Parse(degree.Text, System.Globalization.CultureInfo.InvariantCulture),
                    float.Parse(prix.Text, System.Globalization.CultureInfo.InvariantCulture), brass.SelectedItem.ToString(),
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
                    otherInfos.Text,
                    alcool.IsChecked.Value,
                    levure.IsChecked.Value,
                    gluten.IsChecked.Value
                    );

                ///Save Data and trigger events
                Mng.DataManager.ProduitDataMng.PropBeerData.AddOneToFile(l);
                Mng.EventHub.OnPropBeerDicChanged(this);
                MessageBox.Show("La proposition a bien été ajouté");
            }
            else
            {
                ///Downloading images process
                prog.Visibility = Visibility.Visible;
                bar.Visibility = Visibility.Visible;
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
                        client.DownloadFileAsync(new Uri(img.Text), "data/img/biere/" + title.Text.ToLower() + "3.png");
                    }
                    Imag3 = "data/img/biere/" + title.Text.ToLower() + "3.png";
                }
                else { MessageBox.Show("Le lien donné n'est pas valable ! Rien n'a été enregistré. . ."); return; }

                ///Try to add beer to Definitiv beer, Remove from Proposition, triggers the two events and save all this data to file
                try
                {
                    var l = new FunctLibrary.Produit.Biere(title.Text, content.Text, float.Parse(degree.Text, System.Globalization.CultureInfo.InvariantCulture),
                        float.Parse(prix.Text, System.Globalization.CultureInfo.InvariantCulture), brass.SelectedValue.ToString(),
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

                    Mng.DataManager.ProduitDataMng.PropBeerData.RemoveOneFromFile(BeerPropName);
                    BeerVal.AddToFinalDictionary();
                    Mng.DataManager.ProduitDataMng.BeerData.AddOneToFile(l);

                    Mng.EventHub.OnBeerDicChanged(this);

                    MessageBox.Show("La biere a bien été ajouté");
                    Mng.EventHub.OnPropBeerDicChanged(this);
                    ReturnToDefaultValue();
                }
                catch (Exception exep)
                {
                    MessageBox.Show(exep.Message);
                }
            }
        }
    }
}