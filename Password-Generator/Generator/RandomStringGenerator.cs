using System;


namespace Password_Generator.Generator
{
    public class RandomStringGenerator //singleton class
    {

        private static RandomStringGenerator _instance;
        private static ListOfGeneratorLetters _letters = new ListOfGeneratorLetters();
        private Random random;

        private const int maxLoops = 5000;

        private RandomStringGenerator()
        {
            random = new Random();   
        }


        public static RandomStringGenerator GetInstance()
        {
            if (_instance == null)
                _instance = new RandomStringGenerator();
            return _instance;
        }

        public string GetRandomString(string characters, int stringLengt, GeneratorSettings generatorSettings)
        {
            if (characters == null)
                throw new ArgumentNullException();

            string randomString;
            char[] chars = characters.ToCharArray();
            int loops = 0;

            do
            {
                randomString = string.Empty;

                while (randomString.Length < stringLengt && loops < maxLoops)
                {
                    char randomCh = chars[random.Next(chars.Length)];
                    if (!randomString.EndsWith(randomCh.ToString()))
                        randomString += randomCh;

                    //Int to check if it is no principle endless loop
                    loops++;
               }
            }while(loops < maxLoops &! ValidString(randomString, generatorSettings));
             

            if (loops >= maxLoops)
                return "Try Again!";

            return randomString;
        }


        private bool ValidString(string str, GeneratorSettings generatorSettings)
        {
            
            if (generatorSettings.LowerCaseLettersActive)
            {
                if (!ContainsSomeChar(str, _letters.LowerLetters.ToCharArray()))
                    return false;
            }

            if (generatorSettings.UpperCaseLettersActive)
            {
                if (!ContainsSomeChar(str, _letters.UpperLetters.ToCharArray()))
                    return false;
            }

            if (generatorSettings.NumbersActive)
            {
                if (!ContainsSomeChar(str, _letters.Numbers.ToCharArray()))
                    return false;
            }

            if (generatorSettings.SpacesActive)
            {
                if (!ContainsSomeChar(str, _letters.Space.ToCharArray()))
                    return false;
            }

            if (generatorSettings.ExclamationMarkActive)
            {
                if (!ContainsSomeChar(str, _letters.ExclamationMarkActive.ToCharArray()))
                    return false;
            }

            if (generatorSettings.SpecialLettersActive)
            {
                if (!ContainsSomeChar(str, _letters.SpecialLetters.ToCharArray()))
                    return false;
            }


            return true;
        }

        private bool ContainsSomeChar(string str, char[] charList)
        {
            foreach (char ch in charList)
            {
                if(str.Contains(ch.ToString()))
                    return true;
            }
            return false;
        }

 
    }
}
