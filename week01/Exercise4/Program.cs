using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.\n");

        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.\n");

        while (true)
        {
            Console.Write("Enter number:");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }

            else
            {
                break;
            }
        }

        numbers.Sort();
        Console.WriteLine($"\nThe sorted list is: [{string.Join(",", numbers)}]");

        int total = 0;
        float avg = 0;
        int max = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            total += numbers[i];
            avg = (float)total / numbers.Count;
            
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        
        Console.WriteLine($"The sum is: {total}\nThe average is: {avg:F3}\nThe largest number is: {max}");

        
    }
}