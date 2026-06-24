using Routine.Entities;

namespace Routine.Features.Reminders.GetReminderById
{
    public class ReminderDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public ReminderType Type { get; set; }
        public string? PresetKey { get; set; }
        public ReminderActionType ActionType { get; set; }
        public string? Note { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<ReminderScheduleDto> Schedules { get; set; } = new List<ReminderScheduleDto>();
    }
}