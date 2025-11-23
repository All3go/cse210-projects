using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void ShowGoals()
    {
        Console.WriteLine("\nYour Goals:");
        int index = 1;

        foreach (var g in _goals)
        {
            Console.WriteLine($"{index}. {g.GetStatus()}");
            index++;
        }
    }

    public void RecordEvent()
    {
        ShowGoals();
        Console.Write("\nWhich goal did you accomplish? Enter the number: ");
        int selection = int.Parse(Console.ReadLine());
        selection--;

        if (selection >= 0 && selection < _goals.Count)
        {
            Goal goal = _goals[selection];

            _score += goal.Points;

            if (goal is ChecklistGoal checklist)
            {
                int before = checklist.GetCurrentCount();
                checklist.RecordEvent();
                int after = checklist.GetCurrentCount();

                if (after == checklist.GetTargetCount())
                {
                    _score += checklist.GetBonus();
                    Console.WriteLine("Bonus awarded for completing the checklist goal!");
                }
            }
            else
            {
                goal.RecordEvent();
            }

            Console.WriteLine($"\nCongratulations! You now have {_score} points!");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nTotal Score: {_score}");
    }

    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);

            foreach (var g in _goals)
            {
                writer.WriteLine(g.GetSaveString());
            }
        }
    }

    public void Load(string filename)
    {
        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            string type = parts[0];

            switch (type)
            {
                case "SimpleGoal":
                    AddGoal(new SimpleGoal(parts[1], parts[2],
                        int.Parse(parts[3]), bool.Parse(parts[4])));
                    break;

                case "EternalGoal":
                    AddGoal(new EternalGoal(parts[1], parts[2],
                        int.Parse(parts[3])));
                    break;

                case "ChecklistGoal":
                    AddGoal(new ChecklistGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]),
                        int.Parse(parts[6])
                    ));
                    break;
            }
        }
    }
}
