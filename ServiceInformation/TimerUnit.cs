namespace ServiceInformation
{
    public class TimerUnit : Unit
    {
        public TimerUnit(string name) : base(name)
        {
            Name += ".timer";
        }
    }
}