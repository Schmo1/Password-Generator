using System;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;
using ToastNotifications;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using Password_Generator.Commands;
using Password_Generator.Core;
using Password_Generator.Generator;


namespace Password_Generator.ViewModel
{
    public class HomeViewModel : ObservableObject
    {


        private string _generatedPassword;
        private ListOfGeneratorLetters listOfGeneratorStrings;
        private GeneratorSettings _generatorSettings;
        private bool _enableAddToClipBoard;


        //PW Textbox
        public string GeneratedPassword
        { 
            get { return _generatedPassword; } 
            set 
            {
                _generatedPassword = value;
                EnableAddToClipBoard = !string.IsNullOrEmpty(_generatedPassword);
                OnPropertyChanged(); 
            }
        }



        //Disable ClipBoardbutton if Textbox is empty
        public bool EnableAddToClipBoard
        {
            get { return !string.IsNullOrEmpty(GeneratedPassword); }
            set { _enableAddToClipBoard = value; OnPropertyChanged(); }
        }



        //Slider informations
        public int PWLenghtMin { get => _generatorSettings.MinPWLength; }    
        public int PWLenghtMax { get => _generatorSettings.MaxPWLength; }
        public int PWLenght { get { return _generatorSettings.PasswordLength; } set { _generatorSettings.PasswordLength = value; OnPropertyChanged(); } }



        //Commands
        public ICommand GeneratePWCommand { get; }
        public ButtonActivCommand AddToClipBoardCommand { get; private set; }



        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: -200,
                offsetY: -10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });




        //Contructor

        public HomeViewModel(GeneratorSettings generatorSettings)
        {

            GeneratePWCommand = new GenerateCommand(this);
            AddToClipBoardCommand = new ButtonActivCommand(AddToClipBoard);

            listOfGeneratorStrings = new ListOfGeneratorLetters(generatorSettings);
            _generatorSettings = generatorSettings;
        }




        //Methods



        public Task GeneratePWAsync()
        {
            //Generate new PW
           GeneratedPassword = RandomStringGenerator.GetInstance().GetRandomString(listOfGeneratorStrings.GetConfiguratedString(), _generatorSettings.PasswordLength, _generatorSettings);
           
           return Task.CompletedTask;
        }



        private void AddToClipBoard()
        {
            
            if (string.IsNullOrEmpty(GeneratedPassword))
            {   //PW is Empty
                //toaster.Show("Generate Password!", "Textbox is Empty", ToastTypes.Error);
                notifier.ShowError("Generate Password!");
                return;
            }
                     
            //Add to ClipBoard
            Clipboard.SetText(GeneratedPassword);
            notifier.ShowSuccess("Added to Clipboard");
            //toaster.Show("Added to clipboard", string.Empty, ToastTypes.Success);
        }



    }
}
