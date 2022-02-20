namespace Merge.Board.Conditions
{
    public class Condition
    {
        
    }

    public class TimerCondition : Condition
    {
        public float IntervalSeconds;
    }
    
    public class UserActionCondition : Condition
    {
        public int ActionsCount;
    }
}