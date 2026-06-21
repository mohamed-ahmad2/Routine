namespace Routine.Entities
{

    public enum ReminderType
    {
        Preset,
        Custom
    }

    public enum ReminderActionType
    {
        DoneSkip,
        DismissOnly,
        PomodoroControls
    }

    public class Reminder
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public ReminderType Type { get; set; }

        // Populated only when Type == Preset (e.g. "WATER", "PRAYER", "SLEEP", "MEAL", "BREAK", "POMODORO")
        public string? PresetKey { get; set; }

        public ReminderActionType ActionType { get; set; }

        public string? Note { get; set; }

        public bool IsEnabled { get; set; } = true;
        public bool IsPreset { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User User { get; set; } = null!;
        public ICollection<ReminderSchedule> Schedules { get; set; } = new List<ReminderSchedule>();
        public ICollection<ReminderLog> Logs { get; set; } = new List<ReminderLog>();
        public ICollection<PomodoroSession> PomodoroSessions { get; set; } = new List<PomodoroSession>();
    }
}
