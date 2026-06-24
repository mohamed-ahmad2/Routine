using Routine.Entities;

namespace Routine.Features.Reminders.CreateReminder
{
    public class CreateReminderDto
    {
        public string Title { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public required ReminderActionType ActionType { get; set; }

        public string? Note { get; set; }

        public bool IsEnabled { get; set; } = true;

        public ICollection<CreateReminderScheduleDto> Schedules { get; set; } = new List<CreateReminderScheduleDto>();
    }
}
