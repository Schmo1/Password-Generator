using System;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;

namespace Password_Generator.Generator
{

    public class GeneratorSettings
    {
        //GeneratePWLengths
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


        public GeneratorSettings()
        {

            CheckSetSettingsValid();

            //Check PasswordLength
            if (PasswordLength < minPWLenght || PasswordLength > maxPWLenght)
                PasswordLength = defaultPWLenght;
        }


        public void CheckSetSettingsValid()
        {
            if (!LowerCaseLettersActive && !UpperCaseLettersActive && !NumbersActive && 
                !SpacesActive && !ExclamationMarkActive && !SpecialLettersActive)
            {
                SetDefault();
            }
            else if (!LowerCaseLettersActive & !UpperCaseLettersActive & !
                NumbersActive && SpacesActive & !ExclamationMarkActive & !
                SpecialLettersActive)
                SetDefault();

        }
        private void SetDefault()
        {


            notifier.ShowWarning("Changed settings to default because of wrong user settings.");

            //Set Default Values
            LowerCaseLettersActive = UpperCaseLettersActive = NumbersActive = true;
        }
    }
}
