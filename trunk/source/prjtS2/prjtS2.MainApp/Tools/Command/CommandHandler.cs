using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace prjtS2.MainApp.Tools.Command
{
    /// <summary>
    /// Default Command Structure
    /// </summary>
    public class CommandHandler : ICommand
    {
        /// <summary>
        /// Funct to exec
        /// </summary>
        private Action<object> _action;

        public CommandHandler(Action<object> action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
