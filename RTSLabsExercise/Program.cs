using System;
using System.Collections.Generic;

namespace RTSLabsExercise
{
    class Program
    {
        static char[] delimiters = {',', '.'};
        static void Main(string[] args)
        {            
            try
            {
                #region AboveBelow
                Console.WriteLine("Above Below:");
                Console.WriteLine("Enter list of numbers separated by a comma or period");
                string[] unparsed = Console.ReadLine().Split(delimiters); //split user input into an array then convert to an array of integers
                int[] parsed = Array.ConvertAll(unparsed, int.Parse);
                Console.WriteLine("Enter number to compare against");
                string numText = Console.ReadLine();
                int num = int.Parse(numText);
                Dictionary<string, List<int>> dic = AboveBelow(parsed, num); //assign function result to dictionary within scope of main
                Console.WriteLine("Numbers above compare value(" + num + "):"); //output all the results
                for (int iter = 0; iter < dic["above"].Count; iter++)
                {
                    Console.WriteLine(dic["above"][iter]);
                }
                Console.WriteLine("Numbers below compare value(" + num + "):");
                for (int iter = 0; iter < dic["below"].Count; iter++)
                {
                    Console.WriteLine(dic["below"][iter]);
                }
                #endregion


                #region stringRotation
                Console.WriteLine("Enter text");
                string text = Console.ReadLine().Trim();
                Console.WriteLine("Enter number for amount of characters to rotate");
                uint rotNum = uint.Parse(Console.ReadLine());
                text = stringRotation(text, rotNum);
                Console.WriteLine("Rotated text: " + text);
                #endregion
            }
            catch
            {
                Console.WriteLine("An error occured. Please quit and try again");
            }
            

        }

        static string stringRotation(string argString, uint r)
        {
            if(r>argString.Length-1) //check if number entered is too large and reduce it to usable number
            {
                r = (uint)(argString.Length-1);
                Console.WriteLine("number entered was greater than length of text. reducing number to 1 less than text size");
            }
            string result = argString.Remove((int)(argString.Length - r)); // assign trimmed version of string
            int n = (int)(argString.Length - r); 
            string holder = argString.Substring(n); //assign rotated part of text to a new string
            return holder + result; //combine strings to produce rotated result
        }

        static Dictionary<string,List<int>> AboveBelow(int[] argNums, int subject)
        {
            Dictionary<string,List<int>> results = new Dictionary<string, List<int>>();//initialize dictionary and both key values
            results.Add("above", new List<int>());
            results.Add("below", new List<int>());
            for (int iter = 0; iter < argNums.Length; iter++) //iterate through all the inputted numbers and compare if higher or lower
            {
                if (argNums[iter] > subject)
                {
                    results["above"].Add(argNums[iter]);
                }
                else
                {
                    results["below"].Add(argNums[iter]);
                }
            }
            return results;
        }
    }
}
