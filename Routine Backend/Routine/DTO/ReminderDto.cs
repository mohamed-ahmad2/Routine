namespace Routine.DTO
{
    public class ReminderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string? PresetKey { get; set; }
        public string ActionType { get; set; } = string.Empty;
        public string? Note { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsPreset { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<ReminderScheduleDto> Schedules { get; set; } = new();
    }
}
