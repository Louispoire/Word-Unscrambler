using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            var matchedwords = new List<MatchedWord>();

            foreach (string scrambledWord in scrambledWords)
            {
                foreach (string word in wordList)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedwords.Add(BuildMatchedWord(scrambledWord, word));
                    }
                    else
                    {
                        var scrambledWordList = scrambledWord.ToArray();
                        var array = word.ToArray();
                        Array.Sort(scrambledWordList);
                        Array.Sort(array);
                        string sortedScrambledWord = new string(scrambledWordList);
                        string word2 = new string(array);
                        if (sortedScrambledWord.Equals(word2, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedwords.Add(BuildMatchedWord(scrambledWord, word));
                        }
                    }
                }

            }

            return matchedwords;
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
