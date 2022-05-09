﻿using System;
using System.Collections.Generic;


namespace Password_Generator.Generator
{
    public class ListOfGeneratorLetters : List<string>
    {
        private GeneratorSettings _settings;


        //To used strings
        public string LowerLetters { get { return "abcdefghijklmnopqrstuvwxyz"; } }
        public string UpperLetters { get { return LowerLetters.ToUpper(); } }
        public string Numbers { get { return "1234567890"; } }
        public string Space { get { return " "; } }
        public string ExclamationMarkActive { get { return "!?."; } }
        public string SpecialLetters { get { return ";:()#-+_/"; } }




        public ListOfGeneratorLetters()
        {
            GenerateDefaultSettings();
        }

        public ListOfGeneratorLetters(GeneratorSettings settings)
        {
            _settings = settings;
        }


        public string GetConfiguratedString()
        {

            UpdateList();


            string returnStr = "";
            foreach (string str in this)
            {
                returnStr += str;
            }

            if (string.IsNullOrEmpty(returnStr))
                throw new ArgumentNullException(nameof(returnStr));

            return returnStr;
        }

        private void GenerateDefaultSettings()
        {
            //New construction generates defaultsvalue
            _settings = new GeneratorSettings();
        }


        public List<string> GetConfiguratedStrings()
        {
            UpdateList();
            return this;
        }




        private void UpdateList()
        {
            Clear();

            _settings.CheckSetSettingsValid();


            if (_settings.LowerCaseLettersActive)
                Add(LowerLetters);

            if (_settings.UpperCaseLettersActive)
                Add(UpperLetters);

            if (_settings.NumbersActive)
                Add(Numbers);

            if (_settings.SpacesActive)
                Add(Space);

            if (_settings.ExclamationMarkActive)
                Add(ExclamationMarkActive);

            if (_settings.SpecialLettersActive)
                Add(SpecialLetters);
        }
        
    
    }
}