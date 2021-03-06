﻿using prjtS2.FunctLibrary.Ressources;
using System;
using System.Windows;
using System.Windows.Input;

namespace prjtS2.MainApp.Tools.Command
{
    /// <summary>
    /// Command for Adding Ressource to DataBase
    /// </summary>
    public class AddRessourceCommand
    {
        /// <summary>
        /// Reference to Manager isntance
        /// </summary>
        Managing.Manager Mng => Managing.Manager.Instance;

        private ICommand _saveRessource;
        /// <summary>
        /// Command call
        /// </summary>
        public ICommand SaveRessource
        {
            get
            {
                return _saveRessource ?? (_saveRessource = new CommandHandler(param => SavingRessource(param)));
            }
        }

        /// <summary>
        /// Check if parameter are acceptable or not
        /// </summary>
        /// <param name="param">list of informations containing type, key, value</param>
        /// <returns>Bool</returns>
        public bool CanExecute(object param)
        {
            if (param is object[] parameters)
            {
                if (!(parameters[0] is string)) { return false; }
                if (!(parameters[1] is string)) { return false; }
                if (!(parameters[2] is string)) { return false; }
                return true;
            }
            return false;

        }

        /// <summary>
        /// Save Ressource if canExecute is true
        /// </summary>
        /// <param name="param">list of informations containing type, key, value</param>
        public void SavingRessource(object param)
        {
            if (!CanExecute(param)) { throw new Exception("Les Arguments Données ne correspondent pas a la valeur souhaité"); }

            var tab = (object[])param;
            string key = (string)tab[0];
            string value = (string)tab[1];
            string lib = (string)tab[2];

            switch(lib)
            {
                case "Types Bieres":
                    //Ressource.Parameter.DICO_TYPE.Add(key.ToLower(), value);
                    Mng.DataManager.RessourceDataMng.TypeBData.AddOneToFile(new TypeBiere(key.ToLower(), value));
                    MessageBox.Show(Ressource.Parameter.DICO_TYPE[key.ToLower()]);
                    break;
                case "Aromes":
                    Ressource.Parameter.DICO_AROMES.Add(key.ToLower(), value);
                    MessageBox.Show(Ressource.Parameter.DICO_AROMES[key.ToLower()]);
                    break;
                case "Cereales":
                    Ressource.Parameter.DICO_COULEURS.Add(key.ToLower(), value);
                    MessageBox.Show(Ressource.Parameter.DICO_CEREALES[key.ToLower()]);
                    break;
                case "Specificite":
                    Ressource.Parameter.DICO_SPEC.Add(key.ToLower(), value);
                    MessageBox.Show(Ressource.Parameter.DICO_SPEC[key.ToLower()]);
                    break;
                case "Style":
                    Ressource.Parameter.DICO_STYLE.Add(key.ToLower(), value);
                    MessageBox.Show(Ressource.Parameter.DICO_STYLE[key.ToLower()]);
                    break;
                case "Couleur":
                    Ressource.Parameter.DICO_COULEURS.Add(key.ToLower(), value);
                    MessageBox.Show(Ressource.Parameter.DICO_COULEURS[key.ToLower()]);
                    break;
                default:
                    throw new Exception("We encountered a Problem and you're data hasn't been saved, please refer to the author of the app");
            }

            Mng.EventHub.OnRessourceDicsChanged(this);

        }
    }
}
