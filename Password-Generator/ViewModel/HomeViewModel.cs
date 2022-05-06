using Password_Generator.Commands;
using Password_Generator.Core;
using System.Windows;

namespace Password_Generator.ViewModel
{
    class HomeViewModel : ObservableObject
    {


        private string _generatedPassword;


        public string GeneratedPassword
        { 
            get { return _generatedPassword; } 
            set { _generatedPassword = value; OnPropertyChanged(); }
        }

        public bool SetToClipboard { get; set; }

        


        public ButtonActivCommand GeneratePWCommand { get; private set; }
        public ButtonActivCommand AddToClipBoardCommand { get; private set; }

        


        //Contructor

        public HomeViewModel()
        {
            GeneratePWCommand = new ButtonActivCommand(GeneratePW);
            AddToClipBoardCommand = new ButtonActivCommand(AddToClipBoard);

        }




        //Methods

        private void GeneratePW()
        {
            MessageBox.Show("test");
        }
        private void AddToClipBoard()
        {
            MessageBox.Show("ClipBoard");
        }

    }
}
