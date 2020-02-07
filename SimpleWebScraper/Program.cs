using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;

namespace SimpleWebScraper
{
    class Program
    {
        private const string Method = "search";
        private const string MainRegex = @"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>";
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter which city you would like to scrape information for");
            var craigListCity = Console.ReadLine()?? string.Empty;
            Console.WriteLine("Please enter the craig list category you would like to scrape");
            var craigListCategoryName = Console.ReadLine() ?? string.Empty;

            try
            {
                using var client=new WebClient();
                string content = client.DownloadString($"http://{craigListCity.Replace(" ",String.Empty)}.craigslist.org/{Method}/{craigListCategoryName}");

                ScrapeCriteria scrapeCriteria=new ScrapeCriteriaBuilder().WithData(content).WithRegex(MainRegex).WithRegexOption(RegexOptions.ExplicitCapture)
                    .WithScrapeCriteriaPart(new ScrapeCriteriaPartBuilder().WithRegex(@">(.*?)</a>").WithRegexOption(RegexOptions.Singleline).Build())
                    .WithScrapeCriteriaPart(new ScrapeCriteriaPartBuilder().WithRegex(@"href=\""(.*?)\""").WithRegexOption(RegexOptions.Singleline).Build())
                    .Build();
                var scrapper =new Scrapper();
                var scrapedElements = scrapper.Scrape(scrapeCriteria);

                if (scrapedElements.Any())
                {
                    foreach (var scrapedElement in scrapedElements)
                    {
                        Console.WriteLine(scrapedElement);
                    } 
                }
                else
                {
                    Console.WriteLine("There were no matched lines for the specified criteria");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }
    }
}
