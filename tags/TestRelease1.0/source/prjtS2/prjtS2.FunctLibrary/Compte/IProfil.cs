using prjtS2.FunctLibrary.Produit;
using prjtS2.FunctLibrary.Ressources;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace prjtS2.FunctLibrary.Compte
{
    /// <summary>
    /// Basic Profil Interfaces needed to create a Profil
    /// </summary>
    public interface IProfil
    {
        int Age { get; }
        string Biographie { get; set; }
        List<Biere> Favoris { get; set; }
        bool HasAlcool { get; }
        bool HasAll { get; }
        bool HasGluten { get; }
        bool HasLevure { get; }
        bool HasNone { get; }
        string Image { get; set; }
        ObservableCollection<Allergene> imperatifs { get; set; }
        Localisation Localisation { get; set; }
        string Mail { get; set; }
        string Nom { get; set; }
        string Password { get; set; }
        string Prenom { get; set; }
        string Username { get; }

        bool CheckPassword(string mdp);
        string GetCryptedPassword(string password, Profil p);
        int GetHashCode();
    }
}