using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        /*
         * CREATIVITY AND EXCEEDING REQUIREMENTS
         
         * In addition to the core requirements, I extended this program
           in several ways:
         
         1. The program contains a library of multiple scriptures instead
            of practicing only one scripture.
         
         2. A scripture is selected randomly from the library, giving the
            user a different scripture to practice.
         
         3. The user can choose how many words to hide after each round.
            This allows the user to control the difficulty of the practice.
         
         4. The program displays a memorization progress percentage showing
            how many words have already been hidden.
         
         5. After completing a scripture, the user can choose another
            scripture from the library and continue practicing.
         
         * These additions are intended to help users practice different
           scriptures and gradually improve their memorization skills.
         */

        // Create a library of scriptures.
        List<Scripture> scriptureLibrary = new List<Scripture>();

        Reference reference1 = new Reference("John", 3, 16);
        string text1 = "For God so loved the world that he gave his only begotten Son";

        Reference reference2 = new Reference("Proverbs", 3, 5, 6);
        string text2 = "Trust in the Lord with all thine heart and lean not unto thine own understanding";

        Reference reference3 = new Reference("Philippians", 4, 13);
        string text3 = "I can do all things through Christ which strengtheneth me";

        Reference reference4 = new Reference("Psalm", 23, 1);
        string text4 = "The Lord is my shepherd I shall not want";

        Reference reference5 = new Reference("Joshua", 1, 9);
        string text5 = "Be strong and of a good courage be not afraid neither be thou dismayed for the Lord thy God is with thee whithersoever thou goest";

        scriptureLibrary.Add(new Scripture(reference1, text1));
        scriptureLibrary.Add(new Scripture(reference2, text2));
        scriptureLibrary.Add(new Scripture(reference3, text3));
        scriptureLibrary.Add(new Scripture(reference4, text4));
        scriptureLibrary.Add(new Scripture(reference5, text5));

        Random random = new Random();

        bool continueProgram = true;

        while (continueProgram)
        {
            // Randomly select a scripture from the library.
            int randomIndex = random.Next(scriptureLibrary.Count);
            Scripture scripture = scriptureLibrary[randomIndex];

            // Display the selected scripture.
            while (true)
            {
                Console.Clear();

                Console.WriteLine("==========================================");
                Console.WriteLine("          SCRIPTURE MEMORIZER");
                Console.WriteLine("==========================================\n");

                Console.WriteLine(scripture.GetDisplayText());

                Console.WriteLine();
                Console.WriteLine(
                    $"Memorization Progress: {scripture.GetProgressPercentage()}%"
                );

                Console.WriteLine(
                    $"Hidden Words: {scripture.GetHiddenWordCount()} / {scripture.GetTotalWordCount()}"
                );

                // End the current scripture when everything is hidden.
                if (scripture.IsCompletelyHidden())
                {
                    Console.WriteLine("\nCongratulations!");
                    Console.WriteLine("You have completely hidden this scripture.");
                    break;
                }

                Console.WriteLine();
                Console.WriteLine("Press ENTER to hide words.");
                Console.WriteLine("Type 'quit' to exit.");
                Console.Write("Type 'new' to choose another scripture: ");

                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    continueProgram = false;
                    break;
                }

                if (input.ToLower() == "new")
                {
                    break;
                }

                // Ask the user how many words to hide.
                Console.Write("How many words would you like to hide? ");

                string numberInput = Console.ReadLine();

                int numberToHide;

                if (int.TryParse(numberInput, out numberToHide))
                {
                    if (numberToHide > 0)
                    {
                        scripture.HideRandomWords(numberToHide);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number greater than 0.");
                        Console.WriteLine("Press ENTER to continue.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                }
            }
        }

        Console.Clear();
        Console.WriteLine("Thank you for using Scripture Memorizer!");
        Console.WriteLine("Keep practicing and keep memorizing!");
    }
}