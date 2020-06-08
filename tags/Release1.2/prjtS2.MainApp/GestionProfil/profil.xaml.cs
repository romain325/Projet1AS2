using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.Compte;
using prjtS2.FunctLibrary.Event;
using prjtS2.MainApp.Managing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour profil.xaml
    /// </summary>
    public partial class Profil : UserControl , INotifyPropertyChanged
    {
        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        public Manager Mng => Manager.Instance;


        private FunctLibrary.Compte.Profil user = null;
        /// <summary>
        /// Profil used for binding
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

        /// <summary>
        /// Initialize the component and the data Structure for Binding
        /// </summary>
        public Profil()
        {     
            InitializeComponent();
            Mng.CoHandl.UserConnected += RecieveProfilInfo;            
        }

        /// <summary>
        /// When Profil info are recieved, adapt page looking and init event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void RecieveProfilInfo(object sender, ProfilEventArgs args)
        {
            User = args.User;
            if (Mng.CoHandl.IsAdmin)
            {
                AdminMode.Visibility = Visibility.Visible;
                Informations.SetValue(Grid.RowProperty, (int)Informations.GetValue(Grid.RowProperty) + 1);
                Informations.SetValue(Grid.RowSpanProperty, (int)Informations.GetValue(Grid.RowSpanProperty) - 1);
            }
            OnPropertyChanged(nameof(User));
            Mng.CoHandl.User.PropertyChanged += OnUserChanged;
        }

        public void OnUserChanged(object sender, EventArgs args)
        {
            OnPropertyChanged("User");
        }

        /// <summary>
        /// GoTo Modification page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modif_Click(object sender, RoutedEventArgs e)
        {
            Mng.Navigation.NavigateTo("modifProfil");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Access to AdminPanel page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminMode_Click(object sender, RoutedEventArgs e)
        {
            if (!Library.ADMIN_PROFIL.Contains(Mng.CoHandl.User.Username)) { MessageBox.Show("Seriously how did you do this?"); }
            else { Mng.Navigation.NavigateTo("adminPanel"); }
            
        }
    }
}
