using System.Collections.Generic;
using System;
using System.Globalization;
using System.Linq;
using System.Security;

namespace ShiftCypher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get String input from the user
            string getString = GetStringInput();
            //Create the random shift value, or for Q.5 get user input for shift
            int shift = GetIntInput();
            //Create a dictionary to hold the cypher keys
            Dictionary<int, string> dict = CreateKey();

            // From Lab 1 Q.5 **Comment out code below in main to use**
            // int[] inputNum = AlphabetPositions(getString, dict);
            // int[] convertedNums = ShiftNums(getString, shift, inputNum);
            // Console.WriteLine($"The phrase {getString} has been converted to {Cypher(convertedNums, dict)} with a shift of {shift}.");

            //Store the cyphered phrase in a variable
            string cypheredWord = "";
            //Foreach loop to create phrase from logic in methods
            foreach (string word in CypherPhrase(getString))
            {
                string punctuation = HasPunctuation(word.ToLower());
                int[] inputNum = AlphabetPositions(word.ToLower(), dict);
                int[] convertedNums = ShiftNums(word.ToLower(), shift, inputNum);
                if (punctuation != "")
                {
                    // inputNum = inputNum.Take(inputNum.Count() - 1).ToArray();
                    convertedNums = convertedNums.Take(convertedNums.Count() - 1).ToArray();
                }

                cypheredWord += (Cypher(convertedNums, dict, IsCapital(word)) + punctuation + " ");
            }

            //Display cyphered phrase to the user.
            Console.WriteLine(cypheredWord.TrimEnd());
        }

        //Method to see if the beginning of each word is capitalized
        static bool IsCapital(string s)
        {
            //User static char method to check first index of each word
            if (char.IsUpper(s[0]))
            {
                return true;
            }

            return false;
        }

        //Method to check punctuation
        static string HasPunctuation(string s)
        {
            //Create variable to store the punc or add an empty string
            string punctuation = "";
            //Get last index to check for punctuation
            int lastIndex = s.Length - 1;
            //If last index is punctuation
            if (char.IsPunctuation(s[lastIndex]))
            {
                //save it in the variable
                punctuation = s[lastIndex].ToString();

            }
            
            //return variable
            return punctuation;
        }

        //Split the phrase at whitespace
        static string[] CypherPhrase(string s)
        {
            //Save the words in an array
            string[] words = s.Split();
            //Return array
            return words;
        }

        //Create random shift value
        static int GetIntInput()
        {
            Random gen = new Random();

            int randomShift = gen.Next(-10, 11);

            return randomShift;
        }


        // From Lab 1 Q.5 ** Gets a shift value from the user, comment out other GetIntInput to use**
        // static int GetIntInput()
        // {
        //     
        //     int inputInt;
        //     bool isInt;
        //     do
        //     {
        //         Console.Write("Input a shift int between 1 - 25: ");
        //         isInt = int.TryParse(Console.ReadLine(), out inputInt);
        //     } while (!isInt || inputInt > 25 || inputInt == 0);
        //
        //     return inputInt;
        // }

        //Get string input from the user
        static string GetStringInput()
        {
            Console.Write("Input a phrase: ");
            string inputString = Console.ReadLine();

            return inputString;
        }

        //Convert string to numeric keys based on their value
        static int[] AlphabetPositions(string s, Dictionary<int, string> dict)
        {
            //Create an array to hold the keys
            int[] inputNum = new int[s.Length];
            int index = 0;
            //foreach loop to iterate chars in the phrase
            foreach (char c in s)
            {
                //Foreach loop to iterate entries in the dict
                foreach (var entry in dict)
                {
                    //If the value in the phrase matches the value in the dict save the key to the array
                    if (c.ToString() == entry.Value)
                    {
                        inputNum[index] = entry.Key;
                        index++;
                        
                        
                    }
                }
            }

            
            return inputNum;
        }

        //Method to shift the nums in the array by the int value of the random generator
        static int[] ShiftNums(string s, int shift, int[] inputNum)
        {
            int index = 0;
            //Create array to hold converted values
            int[] convertedNums = new int[s.Length];
            //Foreach loop to iterate through the nums in the original array
            foreach (var num in inputNum)
            {
                
                //calculate for values out of range
                if ((num + shift) > 25)
                {
                    convertedNums[index] = (num + shift) - 25;
                }
                else if (num + shift < 0)
                {
                    convertedNums[index] = (num + shift) + 25;
                }
                else
                {
                    convertedNums[index] = num + shift;
                }
                index++;
                
            }

            return convertedNums;
        }

        //Cypher the keys into the values at that location in the dict
        static string Cypher(int[] convertedNums, Dictionary<int, string> dict, bool capital)
        {
            string shiftedWord = "";

            foreach (int num in convertedNums)
            {
                shiftedWord += dict[num];
                ;
            }

            //if the word was capitalized, capitalize the letter at the first index of that word
            if (capital)
            {
                shiftedWord = shiftedWord.Substring(0, 1).ToUpper() + shiftedWord.Substring(1);
            }

            return shiftedWord;
        }

        //Create the dictionary of values for the cypher
        static Dictionary<int, string> CreateKey()
        {
            Dictionary<int, string> alphabet = new Dictionary<int, string>();

            alphabet.Add(0, "a");
            alphabet.Add(1, "b");
            alphabet.Add(2, "c");
            alphabet.Add(3, "d");
            alphabet.Add(4, "e");
            alphabet.Add(5, "f");
            alphabet.Add(6, "g");
            alphabet.Add(7, "h");
            alphabet.Add(8, "i");
            alphabet.Add(9, "j");
            alphabet.Add(10, "k");
            alphabet.Add(11, "l");
            alphabet.Add(12, "m");
            alphabet.Add(13, "n");
            alphabet.Add(14, "o");
            alphabet.Add(15, "p");
            alphabet.Add(16, "q");
            alphabet.Add(17, "r");
            alphabet.Add(18, "s");
            alphabet.Add(19, "t");
            alphabet.Add(20, "u");
            alphabet.Add(21, "v");
            alphabet.Add(22, "w");
            alphabet.Add(23, "x");
            alphabet.Add(24, "y");
            alphabet.Add(25, "z");

            return alphabet;
        }
    }
}