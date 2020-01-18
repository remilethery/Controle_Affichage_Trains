using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RealTimeTransportPublisher.Commands
{
    class CommandPublisher : ICommand
    {

        Action<object> _execute;
        Func<object, bool> _canexecute;

        public CommandPublisher(Action<object> execute,
                                 Func<object, bool> canexecute)
        {
            this._execute = execute;
            this._canexecute = canexecute;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return this._canexecute(parameter);
        }

        void ICommand.Execute(object parameter)
        {
            this._execute(parameter);
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

    }
}
