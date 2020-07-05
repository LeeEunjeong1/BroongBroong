using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BroongBroong.ViewModel
{
    class Command : ICommand
    {
        Action _action;
        //Func<object, bool> _func;

        public Command(Action action)
        {
            _action = action;

        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
