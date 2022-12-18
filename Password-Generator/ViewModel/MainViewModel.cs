using Password_Generator.Core;

namespace Password_Generator.ViewModel
{
    class MainViewModel : ObservableObject
    {

        //Menu Button commands
        public CommandHandler HomeViewCommand { get; set; }
        public CommandHandler SettingsViewCommand { get; set; }
        public CommandHandler InfoViewCommand { get; set; }



        //Views
        public HomeViewModel HomeVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }
        public AboutViewModel AboutVM { get; set; }




        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        //Constructor
        public MainViewModel()
        {
            CreateViewModels();
            CurrentView = HomeVM;

            string test = System.Threading.Thread.CurrentThread.CurrentUICulture.EnglishName;
            string test2 = System.Threading.Thread.CurrentThread.CurrentCulture.EnglishName;

            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
        }


        private void CreateViewModels()
        {
            //Create Models
            SettingsVM = new SettingsViewModel();
            HomeVM = new HomeViewModel(SettingsVM.Settings); 
            AboutVM = new AboutViewModel();

            //Create Commands
            HomeViewCommand = new CommandHandler(() => CurrentView = HomeVM, () => true);
            SettingsViewCommand = new CommandHandler(() => CurrentView = SettingsVM, () => true);
            InfoViewCommand = new CommandHandler(() => CurrentView = AboutVM, () => true);
        }

    }
}
