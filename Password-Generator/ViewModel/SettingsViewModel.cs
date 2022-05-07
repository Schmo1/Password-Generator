using Password_Generator.Generator;
using Password_Generator.Core;

namespace Password_Generator.ViewModel
{
    class SettingsViewModel : ObservableObject
    {


        public GeneratorSettings Settings { get; set; }




        public SettingsViewModel()
        {
            Settings = new GeneratorSettings();
        }


    }
}
