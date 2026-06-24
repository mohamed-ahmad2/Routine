using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Routine.Common.Persistence;
using Routine.Entities;
using Routine.Features.Reminders.CreateReminder;
using System.Text.Json.Serialization;

namespace Routine
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<RoutineDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            builder.Services.AddValidatorsFromAssemblyContaining<CreateReminderValidator>();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddAutoMapper(cfg => { }, typeof(CreateReminderValidator).Assembly);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            //app.UseMiddleware<DeviceAuthMiddleware>();
            app.UseAuthorization();
            app.MapControllers();

            await app.RunAsync();
        }
    }
}