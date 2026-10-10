/*
 * Creativity and Exceeding Requirements:
 
 * I enhanced the Eternal Quest program with a gamification system
   that rewards users for making progress toward their personal goals.
 
 * The enhancement includes a leveling system based on accumulated
   points, with special titles awarded as the user's score increases.
 * For example, users can progress from Beginner to Goal Seeker,
   Quest Champion, and Eternal Legend.
 
 * This makes the program more engaging by giving users milestones
   to work toward in addition to earning points for individual goals.
 
 * The system extends the original goal-tracking functionality while
   maintaining inheritance, polymorphism, encapsulation, and abstraction.
 */




using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}


