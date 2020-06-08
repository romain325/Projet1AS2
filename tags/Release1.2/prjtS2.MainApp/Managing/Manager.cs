using prjtS2.FunctLibrary;
using prjtS2.MainApp.Tools;
using prjtS2.Persistance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Text;
using System.Windows;

namespace prjtS2.MainApp.Managing
{
    /// <summary>
    /// Manager Class
    /// Contains a Singleton and all the other managing class
    /// !!!!!!! ONLY CALL IT BY USING INSTANCE !!!!!!!!!!!!!!
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// DbInteraction System
        /// </summary>
        public DbDataManager DataManager => ((App)Application.Current).DbDataManager;

        private Manager() { }
        private static Manager _instance;
        private static readonly object padlock = new object();
        public static Manager Instance
        {
            get
            {
                lock (padlock)
                {
                    if(_instance == null)
                    {
                        _instance = new Manager();
                    }
                    return _instance;
                }
                
            }
        }

        /// <summary>
        /// Navigation System
        /// </summary>
        public Navigation Navigation { get; } = new Navigation();

        /// <summary>
        /// ConnexionHandler System
        /// </summary>
        public ConnexionHandler CoHandl { get; } = new ConnexionHandler();

        /// <summary>
        /// Event Hub System 
        /// </summary>
        public EventHub EventHub { get; } = new EventHub();

    }
}
