using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Security;

namespace WordUnscrambler
{
    class Program
    {
        
        private static FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();
        static void Main(string[] args)
        {
            bool endProg = false;
            bool verif = false;
            while (endProg == false)
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
                    while (verif != true)
                    {
                        Console.WriteLine("F - File | M - Manually");
                    string option = Console.ReadLine() ?? throw new Exception("String is empty");

                    
                        switch (option.ToUpper())
                        {
                            case "F":
                                Console.WriteLine("Enter full path and filename: ");
                                ExecuteScrambledWordsInFileScenario();
                                verif = true;
                                break;
                            case "M":
                                Console.WriteLine("Enter word(s) separated by a comma! ***DO NOT PUT A SPACE BETWEEN COMMA AND WORD PLEASE");
                                ExecuteScrambledWordsManualEntryScenario();
                                Console.WriteLine("Press <enter> to proceed.");
                                verif = true;
                                break;
                            default:
                                Console.WriteLine("The entered option was not recognized");
                                verif = false;

                                continue;
                              
                        }
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
                Console.WriteLine("Do you wish to continue? Y or N");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "y")
                {
                    verif = false;
                    continue;
                }
                if (answer.ToLower() == "n")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
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
            string enteredWord = Console.ReadLine();
            string[] scrambledWords = enteredWord.Split(',');
            DisplayMatchedScrambledWords(scrambledWords);
        }
        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordList = fileReader.read(@"C:\Users\lpsim\Source\Repos\Word-Unscrambler\WordUnscrambler\wordlist.txt");
            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);
            int i = 1;
            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine("Match " + i + " has been found for {0} {1}", matchedWord.ScrambledWord, matchedWord.Word);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("No match. Please retry!");
            }
        }
        
    }
}
