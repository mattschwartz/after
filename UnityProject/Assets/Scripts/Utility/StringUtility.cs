using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace After.Utility
{
    public class StringUtility
    {
        private static List<char> Vowels = new List<char> { 'a', 'e', 'i', 'o' };

        public static string AorAn(string str, bool capitalized = false)
        {
            char a = capitalized ? 'A' : 'a';
            if (Vowels.Contains(str[0])) {
                return a + "n " + str;
            }

            return a + " " + str;
        }
    }
}
