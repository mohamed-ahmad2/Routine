using Microsoft.EntityFrameworkCore;
using Routine.Common.Persistence;
using Routine.Entities;

namespace Routine.Middleware
{
    public class DeviceAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public DeviceAuthMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context, RoutineDbContext db)
        {
            var deviceId = context.Request.Headers["X-Device-Id"].FirstOrDefault();

            if (string.IsNullOrEmpty(deviceId))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Missing Device ID");
                return;
            }

            var user = await db.Users.FirstOrDefaultAsync(u => u.DeviceId == deviceId);
            if (user == null)
            {
                user = new User
                {
                    DeviceId = deviceId,
                    CreatedAt = DateTime.UtcNow
                };
                db.Users.Add(user);
                await db.SaveChangesAsync();
            }

            context.Items["UserId"] = user.Id;

            await _next(context);
        }
    }
}