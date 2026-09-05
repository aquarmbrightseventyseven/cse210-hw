using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        int secretNumber;
        int guess = 0;
        int guessLimit = 3;       // quit the game after three guess
        int guessCount;
        string request = "yes";

        Console.WriteLine("\nWelcome to Guess My Number game!\n");

        while (request != "no")
        {
            // Generate random numbers from 1 to 100
            Random random = new Random();
            secretNumber = random.Next(1, 101);
            
            guessCount = 0;

            while (guessCount < guessLimit)
            {
                Console.Write("\nWhat is the magic number(0-100)? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;
                
                // Give hint on wrong guess, congratulate on right guess.
                if (guess > secretNumber)
                {
                    Console.WriteLine("Too High!");

                }

                else if (guess < secretNumber)
                {
                    Console.WriteLine("Too Low!");
                }

                else
                {
                    Console.WriteLine("\nCongratulation!! You guessed it!");
                    break;
                }
            
            }

            // When wrongly guessed three times

            if (guess != secretNumber)
            {
                Console.WriteLine("\nYou lost the game!!");
                Console.WriteLine($"The magic number is {secretNumber}");
            }
        

            Console.Write("\nWould you like to play again (yes/no)? ");
            request = Console.ReadLine().ToLower();    

        }

        Console.WriteLine("\nThank you for playing! Goodbye!");



    }
}