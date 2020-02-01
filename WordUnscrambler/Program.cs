using System;
using System.Collections.Generic;
using System.Linq;
using WordUnscrambler.Data;
using WordUnscrambler.Workers;
using  static WordUnscrambler.Data.Constants;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader FileReader=new FileReader();
        private static readonly WordMatcher WordMatcher=new WordMatcher();
        static  string wordListFileName = "WordList.txt";


        static void Main(string[] args)
        {
            try
            {
                bool continueWordUnscramble = true;
                do
                {
                    Console.WriteLine(EnterOptionForHowToEnterScrambledWords);
                    var option = Console.ReadLine() ?? string.Empty;
                    switch (option.ToUpper())
                    {
                        case File:
                            Console.WriteLine(EnterScrambledWordsFileNameEntryOption);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case Manual:
                            Console.WriteLine(EnterWordsManuallyOption);
                            ExecuteScrambledWordsInManualEntryScenario();

                            break;
                        default:
                            Console.WriteLine(OptionNotRecognized);

                            break;
                    }

                    var unscrambleDecision = string.Empty;

                    do
                    {
                        Console.WriteLine(EnterScrambledWordsDoYouWantToContinue);
                        unscrambleDecision = Console.ReadLine()??string.Empty;
                
                    } while (unscrambleDecision.Equals(Yes,StringComparison.OrdinalIgnoreCase)&& unscrambleDecision.Equals(No,StringComparison.OrdinalIgnoreCase));

                    continueWordUnscramble = unscrambleDecision.Equals(Yes, StringComparison.OrdinalIgnoreCase);
                } while (continueWordUnscramble);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{ErrorProgramWillBeTerminated }\n{e.Message}");
            }
        }

        private static void ExecuteScrambledWordsInManualEntryScenario()
        {
            var manualInput = Console.ReadLine()??string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);

        }


        private static void ExecuteScrambledWordsInFileScenario()
        {
            var fileName = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = FileReader.Read(fileName);
            DisplayMatchedUnscrambledWords(scrambledWords);

        }



        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordList = FileReader.Read(wordListFileName);

            List<MatchedWord> matchedWords = WordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine($"Match found for {matchedWord.ScrambledWord} : {matchedWord.Word}");
                }
            }
            else
            {
                Console.WriteLine(MatchNotFound);
            }
        }

    }
}
