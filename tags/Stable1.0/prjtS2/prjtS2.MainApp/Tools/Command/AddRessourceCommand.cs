using prjtS2.FunctLibrary.Ressources;
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
            if (!CanExecute(param)) { MessageBox.Show("Les Arguments Données ne correspondent pas a la valeur souhaité");return;}

            var tab = (object[])param;
            string key = (string)tab[0];
            string value = (string)tab[1];
            string lib = (string)tab[2];
            try
            {
                switch (lib)
                {
                    case "Types Bieres":
                        Mng.DataManager.RessourceDataMng.TypeBData.AddOneToFile(new TypeBiere(key.ToLower(), value));
                        break;
                    case "Aromes":
                        Mng.DataManager.RessourceDataMng.AromeData.AddOneToFile(new Arome(key.ToLower(), value));
                        break;
                    case "Cereales":
                        Mng.DataManager.RessourceDataMng.CerealeData.AddOneToFile(new Cereale(key.ToLower(), value));
                        break;
                    case "Specificite":
                        Mng.DataManager.RessourceDataMng.SpecData.AddOneToFile(new Specificite(key.ToLower(), value));
                        break;
                    case "Style":
                        Mng.DataManager.RessourceDataMng.StyleData.AddOneToFile(new FunctLibrary.Ressources.Style(key.ToLower(), value));
                        break;
                    case "Couleur":
                        Mng.DataManager.RessourceDataMng.CouleurData.AddOneToFile(new Couleur(key.ToLower(), value));
                        break;
                    default:
                        throw new Exception("We encountered a Problem and you're data hasn't been saved, please refer to the author of the app");
                }
                MessageBox.Show("Your parameter has been well added!!");
                Mng.EventHub.OnRessourceDicsChanged(this);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            



        }
    }
}
