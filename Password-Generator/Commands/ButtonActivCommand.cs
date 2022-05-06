using System;
using System.Windows.Input;

namespace Password_Generator.Commands
{
    public class ButtonActivCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute;

        public ButtonActivCommand (Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
