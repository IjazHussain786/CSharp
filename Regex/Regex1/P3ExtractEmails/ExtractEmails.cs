using System;
using System.Text.RegularExpressions;

namespace P3ExtractEmails
{
    class ExtractEmails
    {
        static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"[\w]+[\.-_]?[\w]@[\w]+[.-_]?[\w]\.[a-zA-Z]+\.?[a-zA-Z]*";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
