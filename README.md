# Routine

A personal desktop habit & focus tracker. Runs quietly in the system tray, nudging you through daily habits (water, prayer times, meals, sleep) and helping you stay in deep work with a built-in Pomodoro timer — with simple analytics to track how consistent you actually are.

Built as a personal project (for me and a friend, for daily use), and as a portfolio piece demonstrating a backend architecture sized appropriately for the problem rather than copy-pasted boilerplate.

## What it does

- **Preset reminders** — built-in habits configured out of the box: drink water (interval-based), prayer times (dynamic, via the Aladhan API based on city), sleep (fixed time, once a night), meals, and stretch breaks (hourly, dismiss-only).
- **Custom reminders** — user-defined reminders with a name, icon, schedule (fixed time or interval), active days, and an optional note.
- **Pomodoro timer** — configurable work/break cycles, running independently or linked to a reminder, with per-cycle tracking (Work / Short Break / Long Break).
- **Notifications with contextual actions** — Done/Skip for trackable habits, Dismiss-only for non-trackable ones (sleep, stretch), and dedicated controls for Pomodoro sessions.
- **Analytics** — daily/weekly/monthly completion rates, streaks, best productivity windows, and total focus time — all derived from logged reminder actions.

## Repository structure

```
Routine/
├── Routine Backend/        # ASP.NET Core Web API
│   └── Routine/
│       ├── Entities/        # EF Core entities (Reminder, ReminderSchedule, ReminderLog,
│       │                    # PomodoroSession, PomodoroCycle, PrayerTimesCache, AppSetting, User)
│       ├── Features/        # Vertical slices — one folder per use case
│       │   ├── Reminders/
│       │   ├── ReminderLogs/
│       │   ├── Pomodoro/
│       │   ├── Analytics/
│       │   └── PrayerTimes/
│       ├── Common/
│       │   └── Persistence/ # DbContext + EF Core Migrations
│       └── Program.cs
├── Routine Frontend/        # Python desktop client (system tray app)
└── .gitignore
```

## Architecture

**Backend — ASP.NET Core, Vertical Slice Architecture**

The API is intentionally **not** built with a full Clean/Onion Architecture (multiple `.csproj` layers, generic repositories, etc.). The domain logic here is straightforward CRUD plus scheduling and aggregation — it doesn't carry the complexity that justifies that level of layering. Instead:

- **Vertical Slice Architecture** — each feature (`CreateReminder`, `LogReminderAction`, `GetWeeklyAnalytics`, ...) lives in its own folder with everything it needs: command/query, handler, validator, and endpoint. Changing one feature never requires touching unrelated code.
- **MediatR** for a lightweight CQRS pattern — endpoints send a request, the matching handler executes it. No shared "God service" accumulating every operation.
- **Minimal APIs** instead of MVC Controllers — each endpoint is mapped right next to its slice, keeping the route definition close to the logic it triggers.
- **EF Core + SQL Server** — single source of truth from day one. No local SQLite cache; the desktop client talks to the API directly over HTTP.
- **No authentication in v1** — this is a two-person personal tool, not a multi-tenant product. Auth can be added later as its own slice without restructuring anything.

**Frontend — Python**

A lightweight desktop client running in the background (system tray), responsible for displaying notifications, capturing user actions (Done/Skip/Dismiss/Snooze), and driving the Pomodoro UI. Talks to the backend exclusively over HTTP — no local database on the client.

## Tech stack

| Layer | Technology |
|---|---|
| Backend | ASP.NET Core (.NET 8/9), EF Core, SQL Server, MediatR, FluentValidation |
| Frontend | Python (system tray desktop app) |
| External API | Aladhan API (prayer times) |
| Hosting | Render (API), SQL Server hosting via databaseasp.net |

## Database schema

Core entities and relationships:

- `Users` → `Reminders`, `PomodoroSessions`
- `Reminders` → `ReminderSchedules`, `ReminderLogs`, `PomodoroSessions` (nullable FK — a Pomodoro session can run independently of any reminder)
- `PomodoroSessions` → `PomodoroCycles`
- `PrayerTimesCache` — local cache of Aladhan API results (unique per date/city/country) so the app can resolve prayer times without hitting the API every time
- `AppSettings` — simple key-value store for general app configuration

## Status

Actively in development. Core entities, DbContext, and initial migration are in place; Vertical Slice features are being implemented incrementally, starting with Reminders CRUD.