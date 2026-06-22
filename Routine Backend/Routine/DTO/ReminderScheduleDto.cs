namespace Routine.DTO
{
    public class ReminderScheduleDto
    {
        public int Id { get; set; }
        public string ScheduleType { get; set; } = string.Empty;
        public TimeOnly? FixedTime { get; set; }
        public int? IntervalMinutes { get; set; }
        public int DaysOfWeekMask { get; set; }
        public bool IsActive { get; set; }
    }
}
