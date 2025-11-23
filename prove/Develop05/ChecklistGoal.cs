using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonus,
        int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = currentCount;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _currentCount++;
    }

    public bool CompletedThisEvent()
    {
        return _currentCount == _targetCount;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public int GetCurrentCount()
    {
        return _currentCount;
    }

    public int GetTargetCount()
    {
        return _targetCount;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus()
    {
        string check = IsComplete() ? "[X]" : "[ ]";
        return $"{check} {Name} ({Description}) --- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_targetCount}|{_bonus}|{_currentCount}";
    }
}

