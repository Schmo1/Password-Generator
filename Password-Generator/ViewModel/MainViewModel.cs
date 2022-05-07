﻿using Password_Generator.Core;

namespace Password_Generator.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public CommandHandler HomeViewCommand { get; set; }
        public CommandHandler SettingsViewCommand { get; set; }
        public CommandHandler InfoViewCommand { get; set; }



        //Views
        public HomeViewModel HomeVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }
        public AboutViewModel InfoVM { get; set; }


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


        //Konstructor
        public MainViewModel()
        {
            CreateViewModels();
            CurrentView = HomeVM;
        }


        private void CreateViewModels()
        {
            //Create Models
            SettingsVM = new SettingsViewModel();
            HomeVM = new HomeViewModel(SettingsVM.Settings);
            InfoVM = new AboutViewModel();
            
            //Create Commands
            HomeViewCommand = new CommandHandler(() => CurrentView = HomeVM, () => true);
            SettingsViewCommand = new CommandHandler(() => CurrentView = SettingsVM, () => true);
            InfoViewCommand = new CommandHandler(() => CurrentView = InfoVM, () => true);
        }

    }
}
