namespace Routine.Entities
{
    public enum ScheduleType
    {
        Fixed,
        Interval,
        Dynamic
    }


    [System.Diagnostics.CodeAnalysis.SuppressMessage("SonarQube", "S2342:Rename...", Justification = "Rule misconfigured for this naming style")]
    [Flags]
    public enum RoutineDayMask
    {
        None = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64,
        All = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday // 127
    }

    public class ReminderSchedule
    {
        public int Id { get; set; }
        public int ReminderId { get; set; }
        public ScheduleType ScheduleType { get; set; }
        public TimeOnly? FixedTime { get; set; }
        public int? IntervalMinutes { get; set; }
        public int DaysOfWeekMask { get; set; } = (int)RoutineDayMask.All;
        public bool IsActive { get; set; } = true;
        public Reminder Reminder { get; set; } = null!;
    }
}