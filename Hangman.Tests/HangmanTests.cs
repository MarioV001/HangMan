using NUnit.Framework;
using HangmanLibrary;

namespace Hangman.Tests
{
    
	public class HangmanTests
	{
		
		private HangmanLibrary.Hangman LiBRef { get; set; } = null!;

		//public HangmanLibrary.Hangman LibReference = new HangmanLibrary.Hangman;
		[SetUp]
		public void Setup()
		{
			LiBRef = new HangmanLibrary.Hangman();
			string GameWord = LiBRef.SetUpWord(true,"TESTER");//this sets up the new word with the "manual"_
															  //method overiding the auto word generation
															  //so we can test it	
		}

		// Implement tests
		[TestCase("TESTER")]
		public void GuessWholeWord_Test(string WordPrefix)
		{
			LiBRef.GuessLetterInput(WordPrefix);
			Assert.AreEqual(171, LiBRef.GetLivesLeft());//this indicates a Winning State
			
		}

		[TestCase("T")]
		public void GuessLetter_Test(string letterPrefix)
		{
			LiBRef.GuessLetterInput(letterPrefix);
			Assert.AreEqual("T__T__", LiBRef.GetGameWord());//this should be the resoult of only passing the T
		}

		[TestCase("H")]
		public void LifeCalculation_Test(string letterPrefix)//this will purposly type wrong Letter
		{
			LiBRef.GuessLetterInput(letterPrefix);
			Assert.AreEqual(11, LiBRef.GetLivesLeft());//should result in life lost
		}

		[Test]
		public void WordGenerator_Test()
		{
			string TempWord = LiBRef.GetRandomWordFromList();
			Assert.NotNull(TempWord);
		}
	}
}