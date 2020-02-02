using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordUnscrambler.Workers;

namespace WordUnscrambler.Unit.Tests
{
    [TestClass]
    public class WordMatcherTests
    {

        private readonly WordMatcher _wordMatcher = new WordMatcher();
        [TestMethod]
        public void ScrambledWordMatchesGivenWordInTheList()
        {
            var words=new string[] {"cat","chair","more"};
            var scrambledwords=new string[] {"omre"};

            var matchedWOrds = _wordMatcher.Match(scrambledwords, words);

            Assert.IsTrue(matchedWOrds.Count==1);
            Assert.IsTrue(matchedWOrds[0].ScrambledWord == "omre");
            //Assert.IsTrue(matchedWOrds[0].Word.Equals("more",StringComparison.OrdinalIgnoreCase));
        }
        
        
        
        [TestMethod]
        public void ScrambledWordsMatchesGivenWordsInTheList()
        {
            var words=new string[] {"cat","chair","more"};
            var scrambledwords=new string[] {"omre","act"};

            var matchedWOrds = _wordMatcher.Match(scrambledwords, words);

            Assert.IsTrue(matchedWOrds.Count==2);
            Assert.IsTrue(matchedWOrds[0].ScrambledWord == "omre");
            Assert.IsTrue(matchedWOrds[0].Word.Equals("more", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(matchedWOrds[1].ScrambledWord == "act");
            Assert.IsTrue(matchedWOrds[1].Word.Equals("cat", StringComparison.OrdinalIgnoreCase));
        }
    }
}
