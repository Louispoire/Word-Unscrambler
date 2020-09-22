using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordlist)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();
            foreach (string scrambledWord in scrambledWords)
            {
                foreach (string word in wordlist)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        // matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word });
                    }
                    else
                    {

                    }
                }
            }
            return null;
        }
        MatchedWord BuildMatchedWord(String scrambledWord, string word)
        {
            MatchedWord matchedword = new MatchedWord()
            {
                ScrambledWord = scrambledWord,
                Word = word,
                
            };
            return matchedword;
        }
    }

        
    
}
