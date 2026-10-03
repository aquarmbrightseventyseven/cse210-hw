using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life "
            + "by having you list as many things as you can in a certain area."
        )
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths you have?",
            "Who are people that you have helped this week?",
            "What are things you are grateful for?",
            "What are things you are proud of?",
            "What are things that make you happy?",
            "What are good memories you have?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine(
            "List as many responses as you can to the following prompt:"
        );
        Console.WriteLine();

        string prompt = GetRandomPrompt();

        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.WriteLine();
        Console.WriteLine();

        List<string> responses = GetListFromUser();

        Console.WriteLine();
        Console.WriteLine($"You listed {responses.Count} items!");

        ShowSpinner(3);

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();

        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }

    private List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");

            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                responses.Add(response);
            }
        }

        return responses;
    }
}