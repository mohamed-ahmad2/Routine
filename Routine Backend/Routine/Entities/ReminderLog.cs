namespace Routine.Entities
{

    public enum ActionTaken
    {
        Pending,  
        Done,
        Skip,
        Dismiss,
        Snooze
    }

    public class ReminderLog
    {
        public int Id { get; set; }
        public int ReminderId { get; set; }

        public DateTime ScheduledAt { get; set; }

        public DateTime? NotifiedAt { get; set; }

        public ActionTaken ActionTaken { get; set; } = ActionTaken.Pending;

        public DateTime? ActionAt { get; set; }

        public DateTime? SnoozedUntil { get; set; }

        public Reminder Reminder { get; set; } = null!;
    }
}
