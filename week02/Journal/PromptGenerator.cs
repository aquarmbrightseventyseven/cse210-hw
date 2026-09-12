using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();

    public PromptGenerator()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        _prompts.Add("What is something new I learned today?");
        _prompts.Add("What is one thing I am grateful for today?");
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();

        int promptNumber = random.Next(0, _prompts.Count);

        return _prompts[promptNumber];
    }
}