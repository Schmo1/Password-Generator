using Password_Generator.Commands;
using Password_Generator.Core;
using Password_Generator.Generator;
using System.Threading.Tasks;
using System.Windows;

namespace Password_Generator.ViewModel
{
    class HomeViewModel : ObservableObject
    {


        private string _generatedPassword;
        private ListOfGeneratorLetters listOfGeneratorStrings;
        private GeneratorSettings _generatorSettings;


        public string GeneratedPassword
        { 
            get { return _generatedPassword; } 
            set { _generatedPassword = value; OnPropertyChanged(); }
        }


        public int PWLenghtMin { get => _generatorSettings.MinPWLength; }    
        public int PWLenghtMax { get => _generatorSettings.MaxPWLength; }
        public int PWLenght { get { return _generatorSettings.PasswordLength; } set { _generatorSettings.PasswordLength = value; OnPropertyChanged(); } }



        public bool SetToClipboard { get; set; }


        


        public ButtonActivCommand GeneratePWCommand { get; private set; }
        public ButtonActivCommand AddToClipBoardCommand { get; private set; }

        


        //Contructor

        public HomeViewModel(GeneratorSettings generatorSettings)
        {
            GeneratePWCommand = new ButtonActivCommand(GeneratePW);
            AddToClipBoardCommand = new ButtonActivCommand(AddToClipBoard);

            listOfGeneratorStrings = new ListOfGeneratorLetters(generatorSettings);
            _generatorSettings = generatorSettings;
        }




        //Methods

        private void GeneratePW()
        {
            GeneratedPassword = RandomStringGenerator.GetInstance().GetRandomString(listOfGeneratorStrings.GetConfiguratedString(), _generatorSettings.PasswordLength, _generatorSettings);
        }
        private void AddToClipBoard()
        {
            MessageBox.Show("ClipBoard");
        }



    }
}
