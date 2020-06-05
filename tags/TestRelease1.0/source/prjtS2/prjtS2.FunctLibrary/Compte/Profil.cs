using prjtS2.FunctLibrary.Event;
using prjtS2.FunctLibrary.Produit;
using prjtS2.FunctLibrary.Ressources;
using prjtS2.FunctLibrary.Tools.Crypto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace prjtS2.FunctLibrary.Compte
{
    /// <summary>
    /// Profil Class representing a person who use the application
    /// </summary>
    public class Profil : INotifyPropertyChanged, IHasAllergenes, IProfil
    {
        private Localisation Loc;
        /// <summary>
        /// Represente the Localisation of the User
        /// </summary>
        public Localisation Localisation
        {
            get => Loc;
            set
            {
                Loc = value ?? throw new Exception("La valeur ne peut pas etre nulle");
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Username of the user, used for connection, Has to be uniq , Can't be changed on the run and either from the Database
        /// Immutable to keep DataBase interaction safe
        /// </summary>
        public string Username { get; }

        private string _Nom;
        /// <summary>
        /// Family Name of the User, Can't be null
        /// </summary>
        public string Nom
        {
            get => _Nom;
            set
            {
                if (value == null || value == "")
                {
                    throw new Exception("La valeur ne peut pas etre nulle");
                }
                _Nom = value;
                OnPropertyChanged();
            }
        }

        private string _Prenom;
        /// <summary>
        /// Name of the User, Can't be null
        /// </summary>
        public string Prenom
        {
            get => _Prenom;
            set
            {
                if (value == null || value == "")
                {
                    throw new Exception("La valeur ne peut pas etre nulle");
                }
                _Prenom = value;
                OnPropertyChanged();
            }
        }

        private string _Bio;
        /// <summary>
        /// Biography of the user (optional)
        /// </summary>
        public string Biographie
        {
            get => _Bio;
            set
            {
                _Bio = value;
                OnPropertyChanged();
            }
        }

        private string _Mail;
        /// <summary>
        /// Email of the user, Has to contains @ and can't be null, needed for future interaction when User Proposition is accepted or not
        /// </summary>
        public string Mail
        {
            get => _Mail;
            set
            {
                if (value == null || value == "" || !value.Contains("@"))
                {
                    throw new Exception("La valeur ne peut pas etre nulle ou doit etre un mail valide");
                }
                _Mail = value;
                OnPropertyChanged();
            }
        }

        private string _Image;
        /// <summary>
        /// Profil Image of the user, Can't be null and is automatically to Default image if so
        /// </summary>
        public string Image
        {
            get => _Image;
            set
            {
                if (value == null || value == "")
                {
                    _Image = "data/logo.png";
                }
                _Image = value;
                OnPropertyChanged();
            }
        }


        private string password;
        /// <summary>
        /// A password keeped Encoded and deEncoded on the run when needed (Authentification only)
        /// WARNING, THE ENCRYPTION IS HAND MADE AND NOT SAFE AT ALL, DON'T TRUST IT 
        /// (I do like to Hack and do some kind of ctf and I just create an encode to avoid lil player that would have just open the Profile file for fun)
        /// </summary>
        public string Password
        {
            get => password;// String.Concat(System.Linq.Enumerable.Repeat("*", password.Length));
            set => this.password = value;
        }

        /// <summary>
        /// Function used to connect, Use Decryption provided by Encrypt static class
        /// </summary>
        /// <param name="mdp">Supposed Password given by User</param>
        /// <returns>Given password is true or not</returns>
        public bool CheckPassword(string mdp)
        {
            if (Tools.Crypto.Encrypt.DecryptString(password, Username + DateNaissance.ToString("MMdd")) == mdp)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Used to Init the CCrypted Password for Data Storage
        /// </summary>
        /// <param name="password">Password you want to Encrypt</param>
        /// <param name="p">The profil from which you want the data</param>
        /// <returns></returns>
        public string GetCryptedPassword(string password, Profil p)
        {
            return Tools.Crypto.Encrypt.EncryptString(password, p.Username + p.DateNaissance.ToString("MMdd"));
        }

        /// <summary>
        /// User's date of birth Immutable and Obligatory
        /// </summary>
        public readonly DateTime DateNaissance;
        /// <summary>
        /// Age of the User
        /// </summary>
        public int Age
        {
            get
            {
                return (int.Parse(DateTime.Now.ToString("yyyyMMdd")) - int.Parse(DateNaissance.ToString("yyyyMMdd"))) / 10000;
            }
        }

        /// <summary>
        /// Listes Favoris de L'utilisateur
        /// </summary>
        public List<Biere> Favoris { get; set; } = new List<Biere>();

        /// <summary>
        /// Liste de tout les différents Parametres d'exclusion à prendre en compte
        /// </summary>
        public ObservableCollection<Allergene> imperatifs { get; set; } = new ObservableCollection<Allergene>();
        private string imp;
        /// <summary>
        /// Used for printing out informations on Profil purely aesthetic
        /// </summary>
        public string Imperatifs
        {
            get
            {
                imp = "";
                if (imperatifs.Count == 0) { imp += "Vous n'avez aucun impératifs à prendre en compte"; }
                else
                {
                    imp += "Vos impératigs à prendre en compte:\n";
                    foreach (Allergene a in imperatifs)
                    {
                        imp += "\t-" + a.ToString() + "\n";
                    }
                }
                return imp;
            }
        }

        /// <summary>
        /// Do we need to exclude alcool of proposed beer
        /// </summary>
        public bool HasAlcool => imperatifs.Contains(Allergene.ALCOOL);
        /// <summary>
        /// Do we need to exclude gluten of proposed beer
        /// </summary>
        public bool HasGluten => imperatifs.Contains(Allergene.GLUTEN);
        /// <summary>
        /// Do we need to exclude levure of proposed beer
        /// </summary>
        public bool HasLevure => imperatifs.Contains(Allergene.LEVURE);
        /// <summary>
        /// Do we need to exclude all of proposed beer
        /// </summary>
        public bool HasAll => HasAlcool && HasLevure && HasGluten;
        /// <summary>
        /// No need to exclude anything of the proposed beers
        /// </summary>
        public bool HasNone => !(HasAlcool || HasLevure || HasGluten);

        /// <summary>
        /// Profil Creation Or Connection
        /// </summary>
        /// <param name="username">Username(Uniq and Immutable)</param>
        /// <param name="nom">Family Name</param>
        /// <param name="prenom">Name</param>
        /// <param name="password">Password(Immutable)</param>
        /// <param name="mail">Email of the User</param>
        /// <param name="dateNaissance">Date of Birth (need to be 18 or more)</param>
        /// <param name="localisation">Localisation/Country of the User</param>
        /// <param name="bio">Biographie (Only used for Connection, default given when create)</param>
        /// <param name="pdp">Profil Pic (Only used for Connection, default given when create)</param>
        /// <param name="connect">Connection --> true, Creation --> false</param>
        public Profil(string username, string nom, string prenom, string password, string mail, DateTime dateNaissance, Localisation localisation, string bio = "Vous n'avez pas encore de description", string pdp = "data/logo.png", bool connect = true)
        {
            if (username is null || nom is null || prenom is null || localisation is null) { throw new ArgumentException("We need more detail so don't let fill empty!"); }
            ///Keep informed of imperatifs changes to actualize IHasAllergenes properties
            imperatifs.CollectionChanged += OnCollectionChanged;

            ///Check if 18 or more
            if (((int.Parse(DateTime.Now.ToString("yyyyMMdd")) - int.Parse(dateNaissance.ToString("yyyyMMdd"))) / 10000) < 18)
            {
                throw new ArgumentException("Les informations indiqués ne sont pas valides");
            }

            ///Encryption of the password if the user is creating an account
            if (!connect)
            {
                if (Library.COMPTES.Contains(username)) { throw new Exception("Malheureusement ce UserName est déjà pris"); }
                if (Encrypt.IsBase64String(password)) { throw new Exception("Votre Mot de passe doit être dans la Base64(Minuscules,Majuscules,Chiffres,/ et +) et pas plus!"); }
                this.Password = GetCryptedPassword(password, this);
            }
            else
            {
                this.Password = password;
            }

            this.Image = pdp;
            this.Username = username;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Mail = mail;
            this.DateNaissance = dateNaissance;
            this.Biographie = bio;
            this.Localisation = localisation;

            Library.COMPTES.Add(this.Username);
        }

        /// <summary>
        /// A Basic ToString Override
        /// </summary>
        /// <returns>A string with all the inforamtions, Used for Debugging</returns>
        public override string ToString()
        {
            string final = "Informations sur " + Nom + " " + Prenom + ":\n";
            final += Password + "  " + Mail + "\n";
            final += Age + "  " + Localisation + "\n\n";
            return final;
        }

        /// <summary>
        /// Actualisation system
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Keep track of any Imperatifs Changes, if so, Update the String Representation of it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            OnPropertyChanged("Imperatifs");
        }

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            OnUserChanged(new ProfilEventArgs(this));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override bool Equals(object obj)
        {
            return obj is Profil profil &&
                   Username == profil.Username;
        }


        public EventHandler<ProfilEventArgs> UserChanged;

        protected virtual void OnUserChanged(ProfilEventArgs args)
        {
            UserChanged?.Invoke(this, args);
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Username);
        }
    }
}
