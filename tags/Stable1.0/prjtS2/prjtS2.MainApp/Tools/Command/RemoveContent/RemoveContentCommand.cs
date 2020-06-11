using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace prjtS2.MainApp.Tools.Command
{
    /// <summary>
    /// Base class used for Removing interaction, see IRemoveContentCommand for Docs
    /// </summary>
    public abstract class RemoveContentCommand : IRemoveContentCommand
    {
        public Managing.Manager Mng => Managing.Manager.Instance;

        private ICommand _RemoveIt;
        public ICommand RemoveIt
        {
            get => _RemoveIt ?? (_RemoveIt = new CommandHandler(param => SavingIt(param)));
        }

        public virtual bool CanExecute(object param)
        {
            if (param is object parameters)
            {
                if (!(parameters is string)) { return false; }
                return true;
            }
            return false;
        }

        public abstract void SavingIt(object param);
    }
}
