using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.\n");

        // Create activities
        Running running = new Running(
            new DateTime(2026, 11, 3), 30, 5.0
        );

        Cycling cycling = new Cycling(
            new DateTime(2026, 11, 4), 30, 20.0
        );

        Swimming swimming = new Swimming(
            new DateTime(2026, 11, 5), 30, 20
        );

        // Store all activities in the same list
        List<Activity> activities = new List<Activity>
        {
            running,
            cycling,
            swimming
        };

        // Display the summary of each activity
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
