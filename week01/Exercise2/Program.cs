using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        // Ask for the user's mark
        Console.Write("Enter your grade percentage(0-100): ");
        string markPct = Console.ReadLine();

        float mark = float.Parse(markPct);
        float lastDigit = mark % 10;

        string sign;
        if (lastDigit >= 7)
        {
            sign = "+";
        }

        else if (lastDigit < 3)
        {
            sign = "-";
        }

        else
        {
            sign = "";
        }

        

        string letter;

        if (mark >= 90)
        {
            letter = "A";
        }

        else if (mark >= 80)
        {
            letter = "B";
        }

        else if (mark >= 70)
        {
            letter = "C";
        }

        else if (mark >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        

        string message;

        if (mark >= 70)
        {
            message = "Congratulation for passing this course.\nKeep it up!";
        }

        else
        {
            message = "You can do better!";
        }

        Console.WriteLine($"Grade: {letter}{sign}");
        Console.WriteLine(message);




    }
}