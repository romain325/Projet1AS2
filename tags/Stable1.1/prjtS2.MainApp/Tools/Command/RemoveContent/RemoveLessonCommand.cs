using prjtS2.FunctLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace prjtS2.MainApp.Tools.Command
{
    /// <summary>
    /// class used for Removing Lesson interaction, see IRemoveContentCommand for Docs
    /// </summary>
    public class RemoveLessonCommand : RemoveContentCommand
    {
        public override void SavingIt(object param)
        {
            if (!CanExecute(param)) { throw new Exception("Les Arguments Données ne correspondent pas a la valeur souhaité"); }
            var val = (string)param;
            MessageBoxResult result = MessageBox.Show("Do you want to remove this lesson: " + param + "?", "Really sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Library.LECON.Remove(val);
                    Mng.DataManager.LeconData.RemoveOneFromFile(val);
                    Mng.EventHub.OnLessonDicChanged(this);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Malheuresement l'opération a subit une erreur durant l'execution:\n" + e.Message, "Oops Something Bad Happend", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
