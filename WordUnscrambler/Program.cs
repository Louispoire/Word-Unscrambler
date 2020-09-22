using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WordUnscrambler
{
    class Program
    {
        private static FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to Unscrambler V4.79");
                Console.Write("Loading.");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.WriteLine("");
                Console.WriteLine("Enter a beautiful scrambled word manually or as a file!");
                Console.WriteLine("");
                Console.WriteLine("F - File | M - Manually");
                string option = Console.ReadLine() ?? throw new Exception("String is empty");
                switch (option.ToUpper())
                {
                    case "F":
                        Console.WriteLine("Enter full path and filename: ");
                        ExecuteScrambledWordsInFileScenario();
                        break;
                    case "M":
                        Console.WriteLine("Enter word(s) separated by a comma");
                        ExecuteScrambledWordsManualEntryScenario();
                        break;
                    default:
                        Console.WriteLine("The entered option was not recognized");
                        break;
                }
                //optional
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error has occured. Please stanby");
                Console.WriteLine("Processing information. Error code : L6-757AH");
                Console.WriteLine(e.Message);
                Console.WriteLine("Loading...");
                Thread.Sleep(4000);
                Console.WriteLine("Loading...");
                Thread.Sleep(2000);
                Console.WriteLine("Shutdown in process.");


            }



        }   
        private static void ExecuteScrambledWordsInFileScenario()
        {
            string fileName = Console.ReadLine();
            string[] scrambledWords = fileReader.read(fileName);
            DisplayMatchedScrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            //Get user input comma separated string conating scrambled words
            //use .split
            
        }
        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordlist = fileReader.read(@"wordlist.txt"); //put a constant file. CAPITAL LETTERS. READ ONLY
            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordlist);

            //Display the matches... use foreach with the list (matchedWords)
            //Rule: use a formatter to display ex: {0}{1}
            //Rule: use a IF to determine if matchedWords is empty or not.......
            //              if empty - display no words found message
            //              if NOT empty - display the matches.... use "foreach" to display every match

        }
    }
}
