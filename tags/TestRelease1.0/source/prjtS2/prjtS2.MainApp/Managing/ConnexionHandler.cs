using prjtS2.FunctLibrary.Compte;
using prjtS2.FunctLibrary.Event;
using prjtS2.FunctLibrary.Ressources;
using prjtS2.MainApp.Managing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace prjtS2.FunctLibrary
{
    /// <summary>
    /// Connexion and User Connected Manager
    /// </summary>
    public class ConnexionHandler
    {
        /// <summary>
        /// Manager Instance
        /// </summary>
        Manager Mng => Manager.Instance;

        /// <summary>
        /// Check if the user is eigtheen or not, if not the program shut down, if true then the program works well
        /// </summary>
        public bool Is18 { get; set; } = false;

        /// <summary>
        /// Check if the user is connected or not
        /// </summary>
        public bool IsConnected { get; private set; } = false;

        /// <summary>
        /// Check if the user is an admin
        /// </summary>
        public bool IsAdmin { get; private set; } = false;

        /// <summary>
        /// The user who's connected (or not)
        /// </summary>
        private Profil user = null;
        /// <summary>
        /// The user who's connected (or not)
        /// </summary>
        public Profil User
        {
            get { return user; }
            private set
            {
                user = value;
                OnUserConnected(new ProfilEventArgs(this.User));
            }
        }



        public EventHandler<ProfilEventArgs> UserConnected;
        protected virtual void OnUserConnected(ProfilEventArgs args)
        {
            UserConnected?.Invoke(this, args);
        }




        /// <summary>
        /// Check if the profil exists and if so, it checks if the password rights
        /// return the username if everything is alright, throw expection else
        /// </summary>
        /// <param name="username">nme of the account</param>
        /// <param name="mdp">password of this account</param>
        /// <returns>the profil from the person who just connect</returns>
        public Profil CheckComptes(string username, string mdp)
        {

            var p = Mng.DataManager.ProfilData.GetOneFromFile(username);
            if (p.CheckPassword(mdp))
            {
                return p;
            }
            else
            {
                Library.COMPTES.Remove(username);
                throw new Exception("The password isn't the right one");
            }

        }

        /// <summary>
        /// Connect a person if the informations are right
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="mdp"> PAssword of the user</param>
        public void Connexion(string username, string mdp)
        {

            Profil profil = CheckComptes(username, mdp);
            if (Library.ADMIN_PROFIL.Contains(username)) { this.IsAdmin = true; }
            User = profil;
            IsConnected = true;

        }
    }
}
