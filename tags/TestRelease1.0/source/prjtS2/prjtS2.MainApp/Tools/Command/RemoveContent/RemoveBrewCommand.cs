using prjtS2.FunctLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace prjtS2.MainApp.Tools.Command
{
    /// <summary>
    /// class used for Removing brewery interaction, see IRemoveContentCommand for Docs
    /// </summary>
    public class RemoveBrewCommand : RemoveContentCommand
    {
        public override bool CanExecute(object param)
        {
            if (param is object parameters)
            {
                if (!(parameters is string)) { return false; }
                if(Library.DICO_BRASSERIES[parameters.ToString()].Bieres.Count != 0) { return false; }
                return true;
            }
            return false;
        }
        public override void SavingIt(object param)
        {
            if (!CanExecute(param)) { throw new Exception("Les Arguments Données ne correspondent pas a la valeur souhaité ou la brasserie contient toujours des bières!"); }
            var val = (string)param;
            MessageBoxResult result = MessageBox.Show("Do you want to remove this brewery: " + param + "?", "Really sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Library.DICO_BRASSERIES.Remove(val);
                    Mng.DataManager.ProduitDataMng.BreweryData.RemoveOneFromFile(val);
                    Mng.EventHub.OnBreweryDicChanged(this);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Malheuresement l'opération a subit une erreur durant l'execution:\n" + e.Message, "Oops Something Bad Happend", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
