using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {}

    public override bool IsComplete() => false;

    public override string GetStatus()
    {
        return $"[∞] {Name} ({Description})";
    }

    public override string GetSaveString()
    {
        return $"EternalGoal:|{Name}|{Description}|{Points}";
    }
}