using prjtS2.MainApp.Managing;
using System.Windows.Input;

namespace prjtS2.MainApp.Tools.Command
{
    /// <summary>
    /// Interfaces used to remove content
    /// </summary>
    public interface IRemoveContentCommand
    {
        /// <summary>
        /// Manager Instance
        /// </summary>
        Manager Mng { get; }

        /// <summary>
        /// Command to call
        /// </summary>
        ICommand RemoveIt { get; }

        /// <summary>
        /// Check if informations are acceptable and can execute program
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        bool CanExecute(object param);
        /// <summary>
        /// Save informations passed
        /// </summary>
        /// <param name="param"></param>
        void SavingIt(object param);
    }
}