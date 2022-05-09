using Password_Generator.ViewModel;
using System;
using System.Threading.Tasks;

namespace Password_Generator.Commands
{
    public class GenerateCommand : AsyncCommandBase
    {

        private readonly HomeViewModel _homeViewModel;

        public GenerateCommand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            await _homeViewModel.GeneratePWAsync();
        }
    }
}
