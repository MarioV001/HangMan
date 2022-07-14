using System;
using HangmanLibrary;

namespace ConsoleApp1
{
    internal class Program
    {
        private static Hangman LiBRef { get; set; } = null!;

        static void Main(string[] args)
        {

            string Readinput="";
            int Stage = 0;
            while (Stage != -1)//new game
            {
                if (Stage == 0)
                {
                    LiBRef = new Hangman();
                    Stage = 1;
                    string GameWord = LiBRef.SetUpWord();//this sets up the new word 
                    Console.Clear();
                    Console.WriteLine("New Game Started");
                    Console.WriteLine("Word is " + LiBRef.GetGameWord().Length + " Characters long");
                    Console.WriteLine("".PadLeft(2) + LiBRef.GetGameWord());//indent and show hidden word
                    PrintGuessLetter();
                    //
                    //Console.WriteLine("".PadLeft(8) + LiBRef.GetGameWord(false));//indent and show non hidden word
                    //used it for testing
                    Readinput = Console.ReadLine();
                }
                else if (Stage == 1)//Started input of word
                {
                    Console.Clear();
                    LiBRef.GuessLetterInput(Readinput);//add new word to list
                    Console.WriteLine("".PadLeft(2) + LiBRef.GetGameWord());//indent and show hidden word
                        
                    //check game state
                    if (LiBRef.GetLivesLeft() == 171)//player has Guessed the word WIN state
                    {
                        Console.Clear();
                        Console.WriteLine("".PadLeft(40) + "============================");
                        Console.WriteLine("".PadLeft(40) + "     CONGRATULATIONS");
                        Console.WriteLine("".PadLeft(40) + "You Have Guessed The Word :)");
                        Console.WriteLine("".PadLeft(40) + "============================");
                        Console.WriteLine("");
                        Console.WriteLine("Press Any Key To Start A [New Game]");
                        Stage = 0;
                        Console.ReadLine();
                    }
                    else if (LiBRef.GetLivesLeft() == 0) //Game over
                    {
                        Console.Clear();
                        Console.WriteLine("".PadLeft(40) + "==============");
                        Console.WriteLine("".PadLeft(40) + "  GAME OVER");
                        Console.WriteLine("".PadLeft(40) + "==============");
                        Console.WriteLine("");
                        Console.WriteLine("Press Any Key To Start A [New Game]");
                        Stage = 0;
                        Console.ReadLine();
                    }
                    else
                    {
                        PrintGuessLetter();
                        Readinput = Console.ReadLine();
                    }
                    //
                    
                }
            }

            //Console.ReadLine();
        }

        static void PrintGuessLetter()
        {
            Console.WriteLine("");
            Console.WriteLine("".PadLeft(32) + "Total Lives: " + LiBRef.GetLivesLeft());
            Console.WriteLine("Guess New letter...");
        }
    }
}
