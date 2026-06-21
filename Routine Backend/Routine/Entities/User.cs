namespace Routine.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public string? AvatarPath { get; set; }

        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();
        public ICollection<PomodoroSession> PomodoroSessions { get; set; } = new List<PomodoroSession>();
    }
}
