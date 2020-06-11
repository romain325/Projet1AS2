using prjtS2.FunctLibrary.Compte;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjtS2.FunctLibrary.Event
{
    /// <summary>
    /// Profil Connected Event, Sends whenever a Person connect to the Profil
    /// Used to avoid null not find Informations
    /// Informations containing the Profil class who will connect 
    /// Can be used to send data from a User (later usage)
    /// </summary>
    public class ProfilEventArgs : EventArgs
    {
        /// <summary>
        /// User informations
        /// </summary>
        public Profil User
        {
            get;
            private set;
        }

        /// <summary>
        /// Default constructor settin the Profil as the EventArgs
        /// </summary>
        /// <param name="profil">Profil data</param>
        public ProfilEventArgs(Profil profil)
        {
            if(profil is null) { throw new Exception("The EventArgs can't be empty"); }
            this.User = profil;
        }
    }
}
