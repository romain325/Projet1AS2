using prjtS2.Persistance;
using System;
using System.Windows;

namespace prjtS2.MainApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// DataBase Manager 
        /// </summary>
        public DbDataManager DbDataManager;

        public App()
        {
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += CurrentDomain_UnhandledException;

            ///Check current User Network Connection
            if (!FunctLibrary.Tools.WebRequest.InternetInteraction.NetworkStatus())
            {
                MessageBox.Show("Vous n'êtes pas connecté à Internet, nous en avons besoin :(( \n Connectez vous pour profiter de cette app!", "Internet is awesome you know..", MessageBoxButton.OK,MessageBoxImage.Exclamation);
                System.Windows.Application.Current.Shutdown();
            }

            ///Initiate DataBaseManager
            DbDataManager = new DbDataManager();
        }

        /// <summary>
        /// Unhandled Exception Gestion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception)e.ExceptionObject;
            MessageBox.Show("UnhandledException caught : " + ex.Message);
            MessageBox.Show("UnhandledException StackTrace : " + ex.StackTrace);
            MessageBox.Show("Runtime terminating: {0}", e.IsTerminating.ToString());
        }
    }
}
