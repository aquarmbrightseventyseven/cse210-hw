
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            int choice = ReadInt("Select an option: ");

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;

                case 2:
                    ListGoalDetails();
                    break;

                case 3:
                    SaveGoals();
                    break;

                case 4:
                    LoadGoals();
                    break;

                case 5:
                    RecordEvent();
                    break;

                case 6:
                    running = false;
                    Console.WriteLine("Thank you for using Eternal Quest!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose 1-6.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYour current score is: {_score}");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have not created any goals yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");

        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nGoal Types");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        int type = ReadInt("Choose the goal type: ");

        if (type < 1 || type > 3)
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("Enter the goal name: ");
        string name = ReadRequiredText();

        Console.Write("Enter the goal description: ");
        string description = ReadRequiredText();

        int points = ReadNonNegativeInt("Enter the points for this goal: ");

        Goal goal;

        switch (type)
        {
            case 1:
                goal = new SimpleGoal(name, description, points);
                break;

            case 2:
                goal = new EternalGoal(name, description, points);
                break;

            case 3:
                int target = ReadPositiveInt(
                    "How many times must this goal be completed? ");

                int bonus = ReadNonNegativeInt(
                    "Enter the bonus points for completing the target: ");

                goal = new ChecklistGoal(
                    name, description, points, target, bonus);
                break;

            default:
                return;
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created successfully.");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record.");
            return;
        }

        Console.WriteLine("\nSelect a goal to record:");
        ListGoalNames();

        int selection = ReadInt("Enter the goal number: ");

        if (selection < 1 || selection > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal selectedGoal = _goals[selection - 1];

        if (selectedGoal.IsComplete())
        {
            Console.WriteLine("This goal is already complete.");
            return;
        }

        int earnedPoints = selectedGoal.RecordEvent();
        _score += earnedPoints;

        Console.WriteLine($"You earned {earnedPoints} points!");
        Console.WriteLine($"Your new score is {_score}.");

        if (selectedGoal.IsComplete())
        {
            Console.WriteLine("Congratulations! You completed this goal.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save to: ");
        string filename = ReadRequiredText();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Could not save the file: {ex.Message}");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You do not have permission to save to that location.");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load: ");
        string filename = ReadRequiredText();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0 ||
                !int.TryParse(lines[0], out int loadedScore) ||
                loadedScore < 0)
            {
                Console.WriteLine("The save file has an invalid score.");
                return;
            }

            List<Goal> loadedGoals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                string[] parts = lines[i].Split('|');

                if (parts.Length < 4 ||
                    !int.TryParse(parts[3], out int points) ||
                    points < 0)
                {
                    Console.WriteLine(
                        $"Skipping invalid goal on line {i + 1}.");
                    continue;
                }

                Goal goal = null;

                switch (parts[0])
                {
                    case "SimpleGoal":
                        if (parts.Length == 5 &&
                            bool.TryParse(parts[4], out bool isComplete))
                        {
                            SimpleGoal simple = new SimpleGoal(
                                parts[1], parts[2], points);

                            simple.SetComplete(isComplete);
                            goal = simple;
                        }
                        break;

                    case "EternalGoal":
                        if (parts.Length == 4)
                        {
                            goal = new EternalGoal(
                                parts[1], parts[2], points);
                        }
                        break;

                    case "ChecklistGoal":
                        if (parts.Length == 7 &&
                            int.TryParse(parts[4], out int completed) &&
                            int.TryParse(parts[5], out int target) &&
                            int.TryParse(parts[6], out int bonus) &&
                            completed >= 0 &&
                            target > 0 &&
                            completed <= target &&
                            bonus >= 0)
                        {
                            ChecklistGoal checklist = new ChecklistGoal(
                                parts[1], parts[2], points, target, bonus);

                            checklist.SetAmountCompleted(completed);
                            goal = checklist;
                        }
                        break;
                }

                if (goal != null)
                {
                    loadedGoals.Add(goal);
                }
                else
                {
                    Console.WriteLine(
                        $"Skipping invalid goal on line {i + 1}.");
                }
            }

            _goals = loadedGoals;
            _score = loadedScore;

            Console.WriteLine("Goals loaded successfully.");
            Console.WriteLine($"Loaded {_goals.Count} goals.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Could not load the file: {ex.Message}");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You do not have permission to read that file.");
        }
    }

    private int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }

            Console.WriteLine("Please enter a valid whole number.");
        }
    }

    private int ReadNonNegativeInt(string prompt)
    {
        while (true)
        {
            int value = ReadInt(prompt);

            if (value >= 0)
            {
                return value;
            }

            Console.WriteLine("Please enter zero or a positive number.");
        }
    }

    private int ReadPositiveInt(string prompt)
    {
        while (true)
        {
            int value = ReadInt(prompt);

            if (value > 0)
            {
                return value;
            }

            Console.WriteLine("Please enter a number greater than zero.");
        }
    }

    private string ReadRequiredText()
    {
        while (true)
        {
            string text = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(text) &&
                !text.Contains('|'))
            {
                return text.Trim();
            }

            Console.WriteLine(
                "Please enter non-empty text without the | character.");
        }
    }


    private void DisplayLevel()
{
    int level;
    string title;
    int nextLevelPoints;

    if (_score < 500)
    {
        level = 1;
        title = "Beginner";
        nextLevelPoints = 500;
    }
    else if (_score < 1500)
    {
        level = 2;
        title = "Goal Seeker";
        nextLevelPoints = 1500;
    }
    else if (_score < 3000)
    {
        level = 3;
        title = "Quest Champion";
        nextLevelPoints = 3000;
    }
    else if (_score < 5000)
    {
        level = 4;
        title = "Master Achiever";
        nextLevelPoints = 5000;
    }
    else
    {
        level = 5;
        title = "Eternal Legend";
        nextLevelPoints = -1;
    }

    Console.WriteLine($"Level: {level}");
    Console.WriteLine($"Title: {title}");

    if (nextLevelPoints != -1)
    {
        Console.WriteLine(
            $"Points to next level: {nextLevelPoints - _score}");
    }
    else
    {
        Console.WriteLine("You have reached the highest level!");
    }
}
}


