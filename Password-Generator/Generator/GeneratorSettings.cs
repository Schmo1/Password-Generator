

namespace Password_Generator.Generator
{

    public class GeneratorSettings
    {

        private const int minPWLenght = 8;
        private const int defaultPWLenght = 20;
        private const int maxPWLenght = 50;




        //Settings
        public bool LowerCaseLettersActive { get => Properties.Settings.Default.LowerCaseLettersActive; set { Properties.Settings.Default.LowerCaseLettersActive = value; Properties.Settings.Default.Save(); } }
        public bool UpperCaseLettersActive { get => Properties.Settings.Default.UpperCaseLettersActive; set { Properties.Settings.Default.UpperCaseLettersActive = value; Properties.Settings.Default.Save(); } }
        public bool NumbersActive { get => Properties.Settings.Default.NumbersActive; set { Properties.Settings.Default.NumbersActive = value; Properties.Settings.Default.Save(); } }
        public bool SpacesActive { get => Properties.Settings.Default.SpacesActive; set { Properties.Settings.Default.SpacesActive = value; Properties.Settings.Default.Save(); } }
        public bool ExclamationMarkActive { get => Properties.Settings.Default.ExclamationMarkActive; set { Properties.Settings.Default.ExclamationMarkActive = value; Properties.Settings.Default.Save(); } }
        public bool SpecialLettersActive { get => Properties.Settings.Default.SpecialLettersActive; set { Properties.Settings.Default.SpecialLettersActive = value; Properties.Settings.Default.Save(); } }

        public int PasswordLength { get => Properties.Settings.Default.PasswordLength; set { Properties.Settings.Default.PasswordLength = value; Properties.Settings.Default.Save(); } }


        public int MinPWLength { get => minPWLenght; }
        public int MaxPWLength { get => maxPWLenght; }


        public GeneratorSettings()
        {
            if (!LowerCaseLettersActive && !UpperCaseLettersActive && !NumbersActive && !SpacesActive && !ExclamationMarkActive && !SpecialLettersActive)
            {
                //Set Default Values
                LowerCaseLettersActive = UpperCaseLettersActive = NumbersActive = true;
            }


            //Check PasswordLength
            if (PasswordLength < minPWLenght || PasswordLength > maxPWLenght)
                PasswordLength = defaultPWLenght;
        }
    }
}
