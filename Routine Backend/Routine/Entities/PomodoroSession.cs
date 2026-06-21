namespace Routine.Entities
{

    public enum PomodoroSessionStatus
    {
        Running,
        Paused,
        Completed,
        Stopped
    }

    public class PomodoroSession
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int? ReminderId { get; set; }

        public int WorkMinutes { get; set; }
        public int BreakMinutes { get; set; }
        public int TotalCycles { get; set; }
        public int CompletedCycles { get; set; }

        public PomodoroSessionStatus Status { get; set; } = PomodoroSessionStatus.Running;

        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }


        public User User { get; set; } = null!;
        public Reminder? Reminder { get; set; }
        public ICollection<PomodoroCycle> Cycles { get; set; } = new List<PomodoroCycle>();
    }
}
