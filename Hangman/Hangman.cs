using System;
using System.Collections.Generic;

namespace HangmanLibrary
{
	/// <summary>
	/// Consider the following game aspects:
	///  * a means of exposing the partially revealed word with placeholders for undiscovered characters
	///  * guessing a character should reveal all occurrences
	///  * the game is won if the entire word is revealed
	///  * the game is lost if you run out of lives after x number of incorrect guesses
	/// </summary>
	/// 
	public class Hangman
	{
		private int TotalLives = 12;//define how many lives are available
		List<string> GuessedLetterlist = new List<string>();
		public string GameWord = "";

		public string SetUpWord(bool Manual = false, string ManualWord ="")
		{
			if(Manual==false) GameWord = GetRandomWordFromList();
			else
            {
				GameWord = ManualWord;
			}
			return GameWord;
		}
		public bool GuessLetter(string Letter)
		{
			char cLetter = char.Parse(Letter);//converts it to char

			return false;
		}
		public string GetGameWord(bool Hidden=true)//this will show the current Word with all guessed characters
		{
			if (GameWord != null)
			{
				string WordBuilder = "";
                if (Hidden == true)
                {
						foreach (char g in GameWord)
						{
							
							if (GuessedLetterlist.Contains(g.ToString().ToUpper()) == true)
							{
								WordBuilder += g.ToString();
							}else WordBuilder += "_";//if letter is not matched
						}
					  if(WordBuilder.ToUpper() == GameWord.ToUpper()) TotalLives = 171;
					return WordBuilder;
				}
                else return GameWord;//if Hidden is false it will show full word
			}
			else return "";
		}
		public void GuessLetterInput(string Letter)
		{
            if (Letter.Length == 1)//if single letter is entered
			{ 
				if (GuessedLetterlist.Contains(Letter.ToUpper()) == false)
						GuessedLetterlist.Add(Letter.ToUpper());
				if (GameWord.ToUpper().Contains(Letter.ToUpper()) == false) TotalLives -= 1;//take lives if Letter is not in word_
																							//ignoring Case sensativity
			}else if (Letter.Length == GameWord.Length)//if they tried to guess the whole Word
            {
				if(Letter.ToUpper()== GameWord.ToUpper())//user guessed the word
                {
					TotalLives = 171;//easy way to set indication of wining;
					//Win
				}
				else TotalLives -= 1;//take live
            }
            else
            {
				//we will not be handling or accepting any charecters in between 1 and word count
            }
		}
		public int GetLivesLeft()
		{
			return TotalLives;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>

		public string GetRandomWordFromList()
		{
			string[] weekDays = new string[4] { "Weekend", "Monday", "Tree", "SpaceShip" };//set up small words list
			Random random = new Random();
			return weekDays[random.Next(0, weekDays.Length)];//return random word from above list
		}

	}



}
