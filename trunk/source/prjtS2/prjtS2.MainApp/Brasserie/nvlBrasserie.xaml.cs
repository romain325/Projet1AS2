using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
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
    /// Logique d'interaction pour nvlBrasserie.xaml
    /// </summary>
    public partial class NvlBrasserie : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        Managing.Manager Mng => Managing.Manager.Instance;


        public NvlBrasserie()
        {
            InitializeComponent();
            country.ItemsSource = Ressource.Parameter.CountryArrays.Values;
        }

        /// <summary>
        /// Submit button interaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valide_Click(object sender, RoutedEventArgs e)
        {
            string Imag1;
            string Imag2;
            string Imag3;

            ///If the brewery val is null so we're using the User Usage --> add to proposition
            ///If the brewery Val is different we're using the Admin Panel --> remove from proposition and add to definitiv
            if(BreweryVal is null)
            {
                if (FunctLibrary.Library.DICO_BRASSERIES.ContainsKey(title.Text.ToLower()) || Library.PROP_BRASSERIES.ContainsKey(title.Text.ToLower())) { MessageBox.Show("Une Brasserie possedant le meme titre existe deja"); return; }


                Imag1 = img.Text;
                Imag2 = img2.Text;
                Imag3 = img3.Text;



                var l = new FunctLibrary.Produit.PropBrasserie(title.Text, content.Text, new Localisation((Ressource.Parameter.CountryArrays.FirstOrDefault(f => f.Value == country.SelectedItem.ToString())).Key),
                    Imag1, Imag2, Imag3, null);


                Mng.DataManager.ProduitDataMng.PropBrewData.AddOneToFile(l);
                Mng.EventHub.OnPropBrewDicChanged(this);
                MessageBox.Show("La proposition a bien été ajouté");
            }
            else
            {
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
                        client.DownloadFileAsync(new Uri(img.Text), "data/img/brasserie/" + title.Text.ToLower() + "1.png");
                    }
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
                    Imag3 = "data/img/brasserie/" + title.Text.ToLower() + "3.png";
                }
                else { MessageBox.Show("Le lien donné n'est pas valable ! Rien n'a été enregistré. . ."); return; }



                try
                {
                    Mng.DataManager.ProduitDataMng.PropBrewData.RemoveOneFromFile(BreweryPropName);
                    BreweryVal.AddToFinalDictionary();
                    var l = new FunctLibrary.Produit.Brasserie(title.Text, content.Text, new Localisation((Ressource.Parameter.CountryArrays.FirstOrDefault(f => f.Value == country.SelectedItem.ToString())).Key),
                        Imag1, Imag2, Imag3);

                    Mng.DataManager.ProduitDataMng.BreweryData.AddOneToFile(l);

                    Mng.EventHub.OnBreweryDicChanged(this);
                    Mng.EventHub.OnPropBrewDicChanged(this);

                    valide.IsEnabled = false;

                }
                catch (Exception exep)
                {
                    MessageBox.Show(exep.Message);
                }

                Mng.EventHub.OnBreweryDicChanged(this);
                Mng.EventHub.OnPropBrewDicChanged(this);
            }



        }

        public int _Progress;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Progress bar value
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
        /// Download status changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void StatusChanged(object sender, DownloadProgressChangedEventArgs args)
        {
            Progress = args.ProgressPercentage / 3;
        }

        /// <summary>
        /// Files has finish download
        /// </summary>
        private void FileFinished()
        {
            prog.Text = "Finished!!";
            bar.Value = 100;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





        /// <summary>
        /// Brewery Dependency Property
        /// </summary>
        public static readonly DependencyProperty BreweryNameProperty = DependencyProperty.Register("BreweryPropName", typeof(string), typeof(NvlBrasserie),
           new PropertyMetadata(null, new PropertyChangedCallback(OnDepPropChanged)));

        /// <summary>
        /// Brewery Name
        /// </summary>
        public string BreweryPropName
        {
            get
            {
                return GetValue(BreweryNameProperty) as string;
            }
            set
            {
                SetValue(BreweryNameProperty, value);
            }
        }

        /// <summary>
        /// Brewery value calculated frm brewery name
        /// </summary>
        public FunctLibrary.Produit.PropBrasserie BreweryVal
        {
            get
            {
                if (BreweryPropName != null)
                {
                    return Library.PROP_BRASSERIES[BreweryPropName];
                }
                else { return null; }
            }
        }

        private static void OnDepPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NvlBrasserie b = d as NvlBrasserie;
            b.OnPropertyChanged(nameof(BreweryVal));
        }

    }
}
