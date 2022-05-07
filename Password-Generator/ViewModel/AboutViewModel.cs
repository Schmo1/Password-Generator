using Password_Generator.Commands;
using Password_Generator.Core;
using System.Diagnostics;
using System.Reflection;
using System.Windows;

namespace Password_Generator.ViewModel
{
    class AboutViewModel : ObservableObject
    {
        
        private const string _gitHubLink = "https://github.com/Schmo1/Password-Generator";



        public string ApplicationName { get { return Application.ResourceAssembly.GetName().Name; } }

        public string VersionNumber { get { return "Version: " + Application.ResourceAssembly.GetName().Version.ToString(); } }
        public string GitHubLink { get { return _gitHubLink; } }



        public ButtonActivCommand OpenGitHubCommand { get; private set; }


        public string CopyRight 
        { 
            get {
                Assembly currentAssem = typeof(AboutViewModel).Assembly;
                object[] attribs = currentAssem.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true);
                string copyright = string.Empty;

                if (attribs.Length > 0)
                {
                    copyright = ((AssemblyCopyrightAttribute)attribs[0]).Copyright;
                }

                if (!string.IsNullOrEmpty(copyright))
                    return copyright;
                else
                    return string.Empty;
            } 
        }



        //Constructor
        public AboutViewModel()
        {

            OpenGitHubCommand = new ButtonActivCommand(OpenGitHubLink);
        }



        //Methods
        private void OpenGitHubLink()
        {
            Process.Start(_gitHubLink);
        }
    }
}
