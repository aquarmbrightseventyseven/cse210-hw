
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int target,
        int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _amountCompleted++;

        int earnedPoints = GetPoints();

        if (_amountCompleted == _target)
        {
            earnedPoints += _bonus;
        }

        return earnedPoints;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";

        return $"{checkbox} {GetName()} - {GetDescription()} " +
               $"(Completed {_amountCompleted}/{_target} times)";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|" +
               $"{GetPoints()}|{_amountCompleted}|{_target}|{_bonus}";
    }

    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }
}
