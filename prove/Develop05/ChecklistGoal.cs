using System;

public class ChecklistGoal : Goal
{
    private int _target;
    private int _count;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int points,
                         int target, int bonus, int count = 0)
        : base(name, desc, points)
    {
        _target = target;
        _count = count;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _count++;
    }

    public override bool IsComplete()
    {
        return _count >= _target;
    }

    public override string GetStatus()
    {
        return $"{(IsComplete() ? "[X]" : "[ ]")} {Name} ({Description}) — {_count}/{_target}";
    }

    public override string SaveData()
    {
        return $"Checklist|{Name}|{Description}|{Points}|{_target}|{_bonus}|{_count}";
    }

    public int GetCount() => _count;
    public int GetTarget() => _target;
    public int GetBonus() => _bonus;

    public bool JustCompleted()
    {
        return _count == _target;
    }
}
