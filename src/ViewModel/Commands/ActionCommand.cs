using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class ActionCommand : ICommand
    {
        // Represents the action to be executed
        private readonly Action action;

        public ActionCommand(Action action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            // The command can always be executed
            return true;
        }

        public void Execute(object parameter)
        {
            // Execute the specified action
            action();
        }
    }
}
