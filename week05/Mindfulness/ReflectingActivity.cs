using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
        : base(
            "Reflecting Activity",
            "This activity will help you reflect on times in your life when you "
            + "have shown strength and resilience. This will help you recognize "
            + "the power you have and how you can use it in other aspects of your life."
        )
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you overcame a challenge.",
            "Think of a time when you learned something important from a difficult experience."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "How did you feel when it was complete?",
            "What did you learn from this experience?",
            "What made this experience difficult?",
            "How did this experience help you grow?",
            "How can you use what you learned in the future?",
            "What other experiences does this remind you of?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        string prompt = GetRandomPrompt();

        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();

        Console.WriteLine(
            "When you have something in mind, press Enter to continue."
        );

        Console.ReadLine();

        Console.Clear();

        List<string> availableQuestions = new List<string>(_questions);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime && availableQuestions.Count > 0)
        {
            string question = GetRandomQuestion(availableQuestions);

            Console.WriteLine();
            Console.WriteLine($"> {question}");
            Console.WriteLine();

            Console.Write("Your reflection: ");
            string reflection = Console.ReadLine();

            Console.WriteLine();

            if (!string.IsNullOrWhiteSpace(reflection))
            {
                Console.WriteLine("Take a moment to think about your response...");
                ShowSpinner(3);
            }

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();

        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }

    private string GetRandomQuestion(List<string> availableQuestions)
    {
        Random random = new Random();

        int index = random.Next(availableQuestions.Count);

        string question = availableQuestions[index];

        availableQuestions.RemoveAt(index);

        return question;
    }
}