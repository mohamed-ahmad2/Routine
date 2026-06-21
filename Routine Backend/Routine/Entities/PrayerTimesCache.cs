namespace Routine.Entities
{

    public class PrayerTimesCache
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public TimeOnly Fajr { get; set; }
        public TimeOnly Dhuhr { get; set; }
        public TimeOnly Asr { get; set; }
        public TimeOnly Maghrib { get; set; }
        public TimeOnly Isha { get; set; }

        public DateTime FetchedAt { get; set; }
    }

}
