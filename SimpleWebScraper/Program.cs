using System;
using System.Net;
using System.Text.RegularExpressions;

namespace SimpleWebScraper
{
    class Program
    {

        
        static void Main(string[] args)
        {
            MatchCollection matches = Regex.Matches("This is my catblah blah...... This is my rat. blah lah lad", "This is my [a-z]at");

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
