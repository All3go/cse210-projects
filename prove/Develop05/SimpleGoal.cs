using System;

public class SimpleGoal : Goal
{
    private bool _done;

    public SimpleGoal(string name, string desc, int points, bool done = false)
        : base(name, desc, points)
    {
        _done = done;
    }

    public override void RecordEvent()
    {
        _done = true;
    }

    public override bool IsComplete()
    {
        return _done;
    }

    public override string GetStatus()
    {
        return (_done ? "[X]" : "[ ]") + $" {Name} ({Description})";
    }

    public override string SaveData()
    {
        return $"Simple|{Name}|{Description}|{Points}|{_done}";
    }
}
