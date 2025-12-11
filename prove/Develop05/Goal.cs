using System;

public abstract class Goal
{
    public string Name;
    public string Description;
    public int Points;

    public Goal(string name, string desc, int points)
    {
        Name = name;
        Description = desc;
        Points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStatus();
    public abstract string SaveData();
}
