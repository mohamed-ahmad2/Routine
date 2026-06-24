using Routine.Entities;

namespace Routine.Features.Reminders.UpdateReminder
{
    public class UpdateReminderDto
    {
        public string Title { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public ReminderActionType ActionType { get; set; }

        public string? Note { get; set; }

        public bool IsEnabled { get; set; } = true;

        public ICollection<UpdateReminderScheduleDto> Schedules { get; set; } = new List<UpdateReminderScheduleDto>();
    }
}
