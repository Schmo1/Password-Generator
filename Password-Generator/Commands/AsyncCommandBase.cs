using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Password_Generator.Commands
{
    public abstract class AsyncCommandBase : ICommand

    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;

        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }


        protected abstract Task ExecuteAsync(object parameter);
    }
}
