using prjtS2.FunctLibrary;
using prjtS2.FunctLibrary.Ressources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace prjtS2.MainApp.Tools.Command
{
    /// <summary>
    /// class used for beer Removing  interaction, see IRemoveContentCommand for Docs
    /// </summary>
    public class RemoveBeerCommand : RemoveContentCommand
    {

        public override void SavingIt(object param)
        {
            if (!CanExecute(param)) { throw new Exception("Les Arguments Données ne correspondent pas a la valeur souhaité"); }
            var val = (string)param;
            MessageBoxResult result = MessageBox.Show("Do you want to remove the beer:"+ param+"?","Really sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if(result == MessageBoxResult.Yes)
            {
                try
                {
                    Library.DICO_BIERES.Remove(val);
                    Mng.DataManager.ProduitDataMng.BeerData.RemoveOneFromFile(val);
                    Mng.EventHub.OnBeerDicChanged(this);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Malheuresement l'opération a subit une erreur durant l'execution:\n" + e.Message,"Oops Something Bad Happend",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
        }
    }
}
