using System;
using System.Globalization;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get input to convert
            Console.Write("Input a word to convert it to Pig Latin: ");
            string input = Console.ReadLine();

            // // Test Screencast Problems
            Console.WriteLine($"Solution to screencast problems : {PigLatin1(input)}");
            // //Test Q.1
            // Console.WriteLine($"Solution to problem 1: {PigLatin2(input)}");
            // //Test Q.2
            // Console.WriteLine($"Solution to problem 2: {PigLatin3(input)}");
            // //Test Q.3
            // Console.WriteLine($"Solution to problem 3: {PigLatin4(input)}");
            // Test Q.4 **Comment out other tests to convert more than one word**
            // Console.WriteLine($"Solution to problem 4: {PigSentence(input)}");
        }

        //Method to check whether or not a string contains a vowel at the first index
        static bool IsVowel(char c)
        {
            c = Char.ToLower(c);
            string vowels = "aeiou";
            return vowels.Contains(c);
        }


        //Method to check the index of the first vowel, return int index
        static int IndexOfFirstVowel(string s)
        {
            int firstVowelIndex = -1;
            foreach (char c in s)
            {
                if (IsVowel(c))
                {
                    firstVowelIndex = s.IndexOf(c);
                    break;
                }
            }

            return firstVowelIndex;
        }

        //Method from Screencasts
        static string PigLatin1(string s)
        {
            string pig = s.Substring(1) + s[0] + "ay";

            return pig;
        }

        //Method from Screencasts
        static string PigLatin2(string s)
        {
            s = s.ToLower();
            string pig;
            int vowelIndex = IndexOfFirstVowel(s);
            if (IsVowel(s[0]))
            {
                pig = s + "way";
            }
            else
            {
                pig = s.Substring(vowelIndex) + s.Substring(0, vowelIndex) + "ay";
            }

            return pig;
        }

        //Method to return a bool if the first word is capitalized
        static bool Index0Capital(string s)
        {
            if (char.IsUpper(s[0]))
            {
                return true;
            }

            return false;
        }

        //Method from Q.1
        static string PigLatin3(string s)
        {
            bool capital = Index0Capital(s);
            s = s.ToLower();
            string pig;
            int vowelIndex = IndexOfFirstVowel(s);
            if (IsVowel(s[0]))
            {
                pig = capital ? (s.Substring(0, 1).ToUpper() + s.Substring(1) + "way") : s + "way";
            }
            else
            {
                if (capital)
                {
                    pig = s.Substring(vowelIndex) + s.Substring(0, vowelIndex) + "ay";
                    string capitalPig = pig.Substring(0, 1).ToUpper() + pig.Substring(1);
                    return capitalPig;
                }

                pig = (s.Substring(vowelIndex) + s.Substring(0, vowelIndex) + "ay");
            }

            return pig;
        }


        //Method to check is the phrase or word has puncutation
        static string HasPunctuation(string s)
        {
            string punctuation = "";

            int lastIndex = s.Length - 1;

            if (char.IsPunctuation(s[lastIndex]))
            {
                punctuation = s[lastIndex].ToString();
            }

            return punctuation;
        }

        //Final method to convert words/phrases to pig latin. Utilizes capitalization, and punctuation
        static string PigLatin4(string s)
        {
            int lastIndex = s.Length - 1;
            string punctuation = HasPunctuation(s);

            if (punctuation != "")
            {
                s = s.Substring(0, lastIndex);
            }

            bool capital = Index0Capital(s);
            s = s.ToLower();
            string pig;
            int vowelIndex = IndexOfFirstVowel(s);
            if (IsVowel(s[0]))
            {
                pig = capital
                    ? (s.Substring(0, 1).ToUpper() + s.Substring(1) + "way") + punctuation
                    : s + "way" + punctuation;
            }
            else if (!s.Contains("a") && !s.Contains("e") && !s.Contains("i") && !s.Contains("o") && !s.Contains("u"))
            {
                if (capital)
                {
                    return s.Substring(0, 1).ToUpper() + s.Substring(1) + "way" + punctuation;
                }

                return s + "way" + punctuation;
            }
            else
            {
                if (capital)
                {
                    pig = s.Substring(vowelIndex) + s.Substring(0, vowelIndex) + "ay";
                    string capitalPig = pig.Substring(0, 1).ToUpper() + pig.Substring(1);

                    return capitalPig + punctuation;
                }

                pig = (s.Substring(vowelIndex) + s.Substring(0, vowelIndex) + "ay");
            }

            return pig + punctuation;
        }

        // Method to utilize above method for multiple words.
        static string PigSentence(string s)
        {
            string[] words = s.Split();
            string pig = "";
            foreach (string word in words)
            {
                string convertedPig = PigLatin4(word);
                pig += convertedPig + " ";
            }

            pig.Trim();
            return pig;
        }
    }
}