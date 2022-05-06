using Password_Generator.Core;

namespace Password_Generator.ViewModel
{
    class SettingsViewModel : ObservableObject
    {

        public bool LowerCaseLettersActiv { get; set; }
        public bool UpperCaseLettersActiv { get; set; }
        public bool NumbersActiv { get; set; }
        public bool SpacesActiv { get; set; }
        public bool ExclamationMarkActiv { get; set; }
        public bool SpecialLettersActiv { get; set; }




        public SettingsViewModel()
        {

        }


    }
}
