using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int points)
        : base(name, desc, points)
    {
    }

    public override void RecordEvent()
    {
    
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStatus()
    {
        return $"[∞] {Name} ({Description})";
    }

    public override string SaveData()
    {
        return $"Eternal|{Name}|{Description}|{Points}";
    }
}
