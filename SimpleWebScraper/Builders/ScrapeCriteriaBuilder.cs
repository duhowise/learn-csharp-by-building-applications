using System.Collections.Generic;
using System.Text.RegularExpressions;
using SimpleWebScraper.Data;
using static System.String;

namespace SimpleWebScraper.Builders
{
    public class ScrapeCriteriaBuilder
    {
        private string _data;
        private string _regex;
        private RegexOptions _regexOption;
        private List<ScrapeCriteriaPart> _scrapeCriteriaParts;


        public ScrapeCriteriaBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _data = Empty;
            _regex = Empty;
            _regexOption = RegexOptions.None;
            _scrapeCriteriaParts = new List<ScrapeCriteriaPart>();
        }



        public ScrapeCriteriaBuilder WithData(string data)
        {
            _data = data;
            return this;
        }
        
        public ScrapeCriteriaBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        } 
        
        public ScrapeCriteriaBuilder WithRegexOption(RegexOptions regexOption)
        {
            _regexOption = regexOption;
            return this;
        }
        public ScrapeCriteriaBuilder WithScrapeCriteriaPart(ScrapeCriteriaPart scrapeCriteriaPart)
        {
            _scrapeCriteriaParts.Add(scrapeCriteriaPart);
            return this;
        }


        public ScrapeCriteria Build()
        {
            return  new ScrapeCriteria
            {
                ScrapeCriteriaParts = _scrapeCriteriaParts,
                Data = _data,
                Regex = _regex,
                RegexOption = _regexOption
                
            };
        }
    }
}