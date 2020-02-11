using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;

namespace SimpleWebScrapper.Test.Unit.Workers
{
    [TestClass]
    public class ScrapperTests
    {

        private readonly Scrapper _scrapper = new Scrapper(); 
        [TestMethod]
        public void FindCollectionWithNoSegments()
        {

            var content = @"some stuff data <a href=""https://boston.craigslist.org/bmw/ctd/d/waltham-2010-lexus-is-250c-base-2dr/7073589362.html"" data-id=""7073589362"" class=""result-title hdrlnk"">2010 Lexus IS 250C Base 2dr Convertible 6A - EASY FINANCING!</a> and more fluff data";



            var scrapeCriteria=new ScrapeCriteriaBuilder()
                    .WithData(content)
                    .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                    .WithRegexOption(RegexOptions.ExplicitCapture)
                    .Build();


            var foundElements = _scrapper.Scrape(scrapeCriteria);

            Assert.IsTrue(foundElements.Count==1);
            Assert.IsTrue(foundElements[0]== @"<a href=""https://boston.craigslist.org/bmw/ctd/d/waltham-2010-lexus-is-250c-base-2dr/7073589362.html"" data-id=""7073589362"" class=""result-title hdrlnk"">2010 Lexus IS 250C Base 2dr Convertible 6A - EASY FINANCING!</a>");
        } 
        
        
        [TestMethod]
        public void FindCollectionWithTwoParts()
        {

            var content = @"some stuff data <a href=""https://boston.craigslist.org/bmw/ctd/d/waltham-2010-lexus-is-250c-base-2dr/7073589362.html"" data-id=""7073589362"" class=""result-title hdrlnk"">2010 Lexus IS 250C Base 2dr Convertible 6A - EASY FINANCING!</a> and more fluff data";



            var scrapeCriteria=new ScrapeCriteriaBuilder()
                    .WithData(content)
                    .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                    .WithRegexOption(RegexOptions.ExplicitCapture)
                    .WithScrapeCriteriaPart(new ScrapeCriteriaPartBuilder()
                        .WithRegex(@">(.*?)</a>")
                        .WithRegexOption(RegexOptions.Singleline)
                        .Build()
                    ).WithScrapeCriteriaPart(new ScrapeCriteriaPartBuilder()
                        .WithRegex(@"href=\""(.*?)\""")
                        .WithRegexOption(RegexOptions.Singleline)
                        .Build()
                    )

                    .Build();


            var foundElements = _scrapper.Scrape(scrapeCriteria);

            Assert.IsTrue(foundElements.Count==2);
            Assert.IsTrue(foundElements[0]== @"2010 Lexus IS 250C Base 2dr Convertible 6A - EASY FINANCING!");
            Assert.IsTrue(foundElements[1]== @"https://boston.craigslist.org/bmw/ctd/d/waltham-2010-lexus-is-250c-base-2dr/7073589362.html");
        }


    }
}
