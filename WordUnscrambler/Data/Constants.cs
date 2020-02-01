using System.Runtime.InteropServices.ComTypes;

namespace WordUnscrambler.Data
{
    public class Constants
    {
        public const string EnterOptionForHowToEnterScrambledWords= "Please enter the option -F for File and M for Manual";
        
        public const string EnterScrambledWordsDoYouWantToContinue = "Do you want to continue? Y/N";
        public const string EnterScrambledWordsFileNameEntryOption = "Enter Scrambled words File Name";
        public const string EnterWordsManuallyOption = "Enter Scrambled words manually seperated by a comma if multiple";
        public const string OptionNotRecognized = "option was not recognized";
        public const string MatchNotFound = "No matches have been found";

        public const string ErrorScrambledWordsCannotBeLoaded = "Scrambled words cannot be loaded because there was an error";
        public const string ErrorProgramWillBeTerminated= "Program will be terminated";
        public const string MatchFound = "Match Found for {0}: {1}";




        public const string Yes= "Y";
        public const string File= "F";
        public const string Manual= "M";
        public const string No= "N";
    }
}