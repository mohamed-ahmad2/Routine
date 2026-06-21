namespace Routine.Entities
{

    public enum CycleType
    {
        Work,
        ShortBreak,
        LongBreak
    }

    public enum CycleStatus
    {
        Running,
        Completed,
        Skipped
    }

    public class PomodoroCycle
    {
        public int Id { get; set; }
        public int SessionId { get; set; }

        public int CycleNumber { get; set; }
        public CycleType CycleType { get; set; }
        public CycleStatus Status { get; set; } = CycleStatus.Running;

        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }

        public PomodoroSession Session { get; set; } = null!;
    }
}
