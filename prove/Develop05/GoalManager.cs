using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    public List<Goal> Goals = new List<Goal>();
    public int Score = 0;

    public void AddGoal(Goal g)
    {
        Goals.Add(g);
    }

    public void ShowGoals()
    {
        Console.WriteLine("\nYour Goals:");
        int i = 1;

        foreach (Goal g in Goals)
        {
            Console.WriteLine($"{i}. {g.GetStatus()}");
            i++;
        }
    }

    public void RecordEvent()
    {
        ShowGoals();
        Console.Write("\nWhich goal number did you complete? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= Goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal g = Goals[index];
        g.RecordEvent();

        Score += g.Points;

        if (g is ChecklistGoal cg && cg.JustCompleted())
        {
            Score += cg.GetBonus();
            Console.WriteLine("Checklist completed! You earned a bonus!");
        }

        Console.WriteLine($"You earned {g.Points} points!");
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nYour score is: {Score}");
    }

    public void Save(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine(Score);

            foreach (Goal g in Goals)
            {
                writer.WriteLine(g.SaveData());
            }
        }
    }

    public void Load(string file)
    {
        Goals.Clear();

        string[] lines = File.ReadAllLines(file);
        Score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] p = lines[i].Split("|");

            if (p[0] == "Simple")
            {
                Goals.Add(new SimpleGoal(p[1], p[2], int.Parse(p[3]), bool.Parse(p[4])));
            }
            else if (p[0] == "Eternal")
            {
                Goals.Add(new EternalGoal(p[1], p[2], int.Parse(p[3])));
            }
            else if (p[0] == "Checklist")
            {
                Goals.Add(new ChecklistGoal(
                    p[1], p[2], int.Parse(p[3]),
                    int.Parse(p[4]), int.Parse(p[5]), int.Parse(p[6])
                ));
            }
        }
    }
}
