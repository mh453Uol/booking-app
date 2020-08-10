using System;
using System.Collections.Generic;
using System.Text;

namespace BarberBooking.Utilities
{
    public static class GrammarUtil
    {
        public static string CommaSeparated(this List<string> words, string separator = ", ", string lastSeparator = " and ")
        {

            if (words.Count == 0)
            {
                return "";
            }

            if (words.Count == 1)
            {
                return words[0];
            }

            var separatedWords = new StringBuilder();
            var tail = (words.Count - 1);

            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine(i);

                //  [(m,)(a,)(j,)(i,)(d)] => m, a, j, i and d
                // 1. If we have have reached tail - 1 element then append and X
                // 2. Else keep appending X, 

                if (i + 1 == tail)
                {
                    separatedWords.Append(words[i]);
                    separatedWords.Append(lastSeparator);
                    separatedWords.Append(words[i + 1]);
                    return separatedWords.ToString();
                }
                else
                {
                    separatedWords.Append(words[i]);
                    separatedWords.Append(separator);
                }

            }

            return separatedWords.ToString();
        }
    }
}