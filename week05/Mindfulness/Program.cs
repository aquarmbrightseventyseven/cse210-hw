using System;
using System.Threading;

/*
 * Creativity and Exceeding Requirements:
 
 * I chose to improve the random prompt and question system.
 
 * In the Reflecting Activity, questions are randomly selected from a list,
   but the program removes each question after it has been used. This prevents
   the same question from appearing again until all of the other questions
   have been used.
 
 * This makes the activity more varied and prevents repetitive questions
   during a session.
 
 * The same idea is used with the prompts in the activities where random
   prompts are selected.
 */

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        
        bool running = true;

        while (running)
        {
            DisplayMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity =
                        new BreathingActivity();

                    breathingActivity.Run();
                    break;

                case "2":
                    ReflectingActivity reflectingActivity =
                        new ReflectingActivity();

                    reflectingActivity.Run();
                    break;

                case "3":
                    ListingActivity listingActivity =
                        new ListingActivity();

                    listingActivity.Run();
                    break;

                case "4":
                    running = false;

                    Console.Clear();
                    Console.WriteLine(
                        "Thank you for using the Mindfulness Program!"
                    );

                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine(
                        "Invalid choice. Please select 1, 2, 3, or 4."
                    );

                    Thread.Sleep(2000);
                    Console.Clear();

                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Quit");

        Console.Write("Select a choice from the menu: ");
    }
}