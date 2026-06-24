using Microsoft.EntityFrameworkCore;
using Routine.Entities;

namespace Routine.Common.Persistence
{

    public class RoutineDbContext : DbContext
    {
        public RoutineDbContext(DbContextOptions<RoutineDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Reminder> Reminders => Set<Reminder>();
        public DbSet<ReminderSchedule> ReminderSchedules => Set<ReminderSchedule>();
        public DbSet<ReminderLog> ReminderLogs => Set<ReminderLog>();
        public DbSet<PomodoroSession> PomodoroSessions => Set<PomodoroSession>();
        public DbSet<PomodoroCycle> PomodoroCycles => Set<PomodoroCycle>();
        public DbSet<PrayerTimesCache> PrayerTimesCaches => Set<PrayerTimesCache>();
        public DbSet<AppSetting> AppSettings => Set<AppSetting>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.DisplayName).HasMaxLength(100).IsRequired();
                entity.Property(u => u.DeviceId).HasMaxLength(36).IsRequired();
                entity.Property(u => u.AvatarPath).HasMaxLength(500);
                entity.Property(u => u.City).HasMaxLength(100).IsRequired();
                entity.Property(u => u.Country).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Reminder>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Title).HasMaxLength(150).IsRequired();
                entity.Property(r => r.Icon).HasMaxLength(50);
                entity.Property(r => r.Category).HasMaxLength(50);
                entity.Property(r => r.PresetKey).HasMaxLength(50);
                entity.Property(r => r.Note).HasMaxLength(500);

                entity.Property(r => r.Type)
                    .HasConversion<string>()
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(r => r.ActionType)
                    .HasConversion<string>()
                    .HasMaxLength(30)
                    .IsRequired();

                entity.HasOne(r => r.User)
                    .WithMany(u => u.Reminders)
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(r => new { r.UserId, r.IsEnabled });
            });

            modelBuilder.Entity<ReminderSchedule>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.ScheduleType)
                    .HasConversion<string>()
                    .HasMaxLength(20)
                    .IsRequired();

                entity.HasOne(s => s.Reminder)
                    .WithMany(r => r.Schedules)
                    .HasForeignKey(s => s.ReminderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(s => s.ReminderId);
            });

            modelBuilder.Entity<ReminderLog>(entity =>
            {
                entity.HasKey(l => l.Id);

                entity.Property(l => l.ActionTaken)
                    .HasConversion<string>()
                    .HasMaxLength(20)
                    .IsRequired();

                entity.HasOne(l => l.Reminder)
                    .WithMany(r => r.Logs)
                    .HasForeignKey(l => l.ReminderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(l => new { l.ReminderId, l.ScheduledAt });
            });

            modelBuilder.Entity<PomodoroSession>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Status)
                    .HasConversion<string>()
                    .HasMaxLength(20)
                    .IsRequired();

                entity.HasOne(p => p.User)
                    .WithMany(u => u.PomodoroSessions)
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(p => p.Reminder)
                    .WithMany(r => r.PomodoroSessions)
                    .HasForeignKey(p => p.ReminderId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(false);

                entity.HasIndex(p => new { p.UserId, p.StartedAt });
            });

            modelBuilder.Entity<PomodoroCycle>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.CycleType)
                    .HasConversion<string>()
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(c => c.Status)
                    .HasConversion<string>()
                    .HasMaxLength(20)
                    .IsRequired();

                entity.HasOne(c => c.Session)
                    .WithMany(s => s.Cycles)
                    .HasForeignKey(c => c.SessionId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(c => c.SessionId);
            });

            modelBuilder.Entity<PrayerTimesCache>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.City).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Country).HasMaxLength(100).IsRequired();

                entity.HasIndex(p => new { p.Date, p.City, p.Country }).IsUnique();
            });

            modelBuilder.Entity<AppSetting>(entity =>
            {
                entity.HasKey(a => a.Key);
                entity.Property(a => a.Key).HasMaxLength(100);
                entity.Property(a => a.Value).HasMaxLength(1000).IsRequired();
            });
        }
    }

}
