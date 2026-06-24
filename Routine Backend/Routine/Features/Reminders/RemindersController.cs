using MediatR;
using Microsoft.AspNetCore.Mvc;
using Routine.Features.Reminders.CreateReminder;
using Routine.Features.Reminders.GetReminders;
using System.Security.Claims;

namespace Routine.Features.Reminders
{
    [ApiController]
    [Route("api/[controller]")]
    public class RemindersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RemindersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetByUserId([FromRoute] int userId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetRemindersQuery(userId), cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReminderDto dto, CancellationToken cancellationToken)
        {
            //var userId = (int)HttpContext.Items["UserId"]!;
            var userId = 1;
            var reminderId = await _mediator.Send(new CreateReminderCommand(userId, dto), cancellationToken);
            return CreatedAtAction(nameof(Create), new { id = reminderId }, new { id = reminderId });
        }
    }
}