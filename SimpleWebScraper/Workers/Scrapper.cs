using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SimpleWebScraper.Data;

namespace SimpleWebScraper.Workers
{
    public class Scrapper
    {
        public List<string> Scrape(ScrapeCriteria scrapeCriteria)
        {
            var scrappedElements = new List<string>();
            MatchCollection matches =
                Regex.Matches(scrapeCriteria.Data, scrapeCriteria.Regex, scrapeCriteria.RegexOption);
            foreach (Match match in matches)
            {
                if (!scrapeCriteria.ScrapeCriteriaParts.Any())
                {
                    scrappedElements.Add(match.Groups[0].Value);
                }
                else
                {
                    foreach (var part in scrapeCriteria.ScrapeCriteriaParts)
                    {
                        Match matchedPart = Regex.Match(match.Groups[0].Value, part.Regex, part.RegexOption);
                        if (matchedPart.Success)
                        {
                            scrappedElements.Add(matchedPart.Groups[1].Value);
                        }
                    }
                }
            }

            return scrappedElements;
        }
    }
}