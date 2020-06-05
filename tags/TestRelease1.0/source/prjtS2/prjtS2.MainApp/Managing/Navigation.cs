using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace prjtS2.MainApp.Managing
{
    public class Navigation : INotifyPropertyChanged
    {
        /// <summary>
        /// Auto implemented when a new UserControls loads up at the beginning
        /// (Avoid any Infinite loop when initiating the Manager Instance!)
        /// </summary>
        public readonly Dictionary<string, UserControl> userControls = new Dictionary<string, UserControl>();

        /// <summary>
        /// Navigate to the given pages, MessageBox if userControl not find
        /// </summary>
        /// <param name="userControl"></param>
        public void NavigateTo(string userControl)
        {
            if (userControls.ContainsKey(userControl))
            {
                SelectedUserControl = userControls.GetValueOrDefault(userControl);
            }
            else
            {
                MessageBox.Show("We're sorry but it seems that the page you try to access doesn't exist :// \n "+ userControl);
            }
            
        }
        


        public event PropertyChangedEventHandler PropertyChanged;

        private UserControl selectedUserControl;
        /// <summary>
        /// Set the actual selected UserControl 
        /// </summary>
        public UserControl SelectedUserControl
        {
            get => selectedUserControl;
            set
            {
                selectedUserControl = value;
                OnPropertyChanged();
            }
        }

        public Navigation()
        {
        }


        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedUserControl)));
        }


    }
}
