using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static prjtS2.FunctLibrary.Ressources.Ressource;

namespace prjtS2.MainApp
{
    /// <summary>
    /// Logique d'interaction pour BlocInfo.xaml
    /// </summary>
    public partial class BlocInfo : UserControl, INotifyPropertyChanged
    {
        public BlocInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Element used for DataBinding
        /// </summary>
        public BaseElement Element
        {
            get
            {
                if (ElemType != Ressource.BlocType.Unknown && 
                    ((LeconName != null) || 
                     (BeerName != null) || 
                     (BreweryName != null) ||
                     (Ajout != BlocType.Unknown)))
                {
                    switch (ElemType)
                    {
                        case Ressource.BlocType.Lecon:
                            if (Library.LECON.ContainsKey(LeconName))
                            {
                                return Library.LECON[LeconName];
                            }
                            else { return null; }

                        case Ressource.BlocType.Brasserie:
                            if (Library.DICO_BRASSERIES.ContainsKey(BreweryName))
                            {
                                return Library.DICO_BRASSERIES[BreweryName];
                            }
                            else { return null; }

                        case Ressource.BlocType.Biere:
                            if (Library.DICO_BIERES.ContainsKey(BeerName))
                            {
                                return Library.DICO_BIERES[BeerName];
                            }
                            else { return null; }

                        case Ressource.BlocType.Ajout:                           
                            return Library.ADD_BLOCK[Ajout];

                        default:
                            return Library.ADD_BLOCK[Ajout];
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Lesson Dependency Property
        /// </summary>
        public static readonly DependencyProperty LeconNameProperty = DependencyProperty.Register("LeconName", typeof(string), typeof(BlocInfo), 
            new PropertyMetadata(null, new PropertyChangedCallback(OnLeconDepChanged)));
        /// <summary>
        /// Brewery Dependency Property
        /// </summary>
        public static readonly DependencyProperty BrasserieProp = DependencyProperty.Register("BreweryName", typeof(string), typeof(BlocInfo),
            new PropertyMetadata(null, new PropertyChangedCallback(OnBreweryDepChanged)));
        /// <summary>
        /// Beer Dependency Property
        /// </summary>
        public static readonly DependencyProperty BiereProp = DependencyProperty.Register("BeerName", typeof(string), typeof(BlocInfo),
            new PropertyMetadata(null, new PropertyChangedCallback(OnBeerDepChanged)));
        /// <summary>
        /// Add Dependency Property
        /// </summary>
        public static readonly DependencyProperty AjoutProp = DependencyProperty.Register("Ajout", typeof(BlocType), typeof(BlocInfo),
            new PropertyMetadata(BlocType.Unknown, new PropertyChangedCallback(OnAjoutDepChanged)));


        public string BreweryName
        {
            get => GetValue(BrasserieProp) as string;
            set
            {
                SetValue(BrasserieProp, value);
            }
        }

        public string BeerName
        {
            get => GetValue(BiereProp) as string;
            set
            {
                SetValue(BiereProp, value);
            }
        }

        public string LeconName
        {
            get
            {
                return GetValue(LeconNameProperty) as string;
            }
            set
            {
                SetValue(LeconNameProperty, value);
            }
        }

        public BlocType Ajout
        {
            get => (BlocType) GetValue(AjoutProp);
            set
            {
                SetValue(AjoutProp, value);
            }
        }



        private static void OnLeconDepChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BlocInfo b = d as BlocInfo;
            b.ElemType = Ressource.BlocType.Lecon;
            b.OnPropertyChanged(nameof(Element));
            b.typePopUp.Content = b.Resources["LeconContentControl"] as ContentControl;
        }
        private static void OnBreweryDepChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BlocInfo b = d as BlocInfo;
            b.ElemType = Ressource.BlocType.Brasserie;
            b.OnPropertyChanged(nameof(Element));
            b.typePopUp.Content = b.Resources["BreweryContentControl"] as ContentControl;
        }
        private static void OnBeerDepChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BlocInfo b = d as BlocInfo;
            b.ElemType = Ressource.BlocType.Biere;
            b.OnPropertyChanged(nameof(Element));
            b.typePopUp.Content = b.Resources["BeerContentControl"] as ContentControl;
        }
        private static void OnAjoutDepChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BlocInfo b = d as BlocInfo;
            b.ElemType = BlocType.Ajout;
            b.OnPropertyChanged(nameof(Element));
            switch (b.Ajout)
            {
                case BlocType.Biere:
                    b.typePopUp.Content = b.Resources["NewBeerContentControl"] as ContentControl;
                    break;
                case BlocType.Brasserie:
                    b.typePopUp.Content = b.Resources["NewBreweryContentControl"] as ContentControl;
                    break;
            }
            
        }

        private Ressource.BlocType ElemType = Ressource.BlocType.Unknown;


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        

    }
}
