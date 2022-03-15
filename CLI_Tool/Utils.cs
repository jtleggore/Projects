using System;
using System.Linq;

namespace CLI_Tool
{
    public static class Utils
    {
        public static string ConvertWord(string word)
        {
            //remove non-alphanumeric chars from word
            word = String.Concat(word.Where(char.IsLetterOrDigit));
            word = word.ToLower();
            return word;
        }
    }
}
