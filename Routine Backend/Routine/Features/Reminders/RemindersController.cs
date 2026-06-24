using MediatR;
using Microsoft.AspNetCore.Mvc;
using Routine.Features.Reminders.CreateReminder;
using Routine.Features.Reminders.DeleteReminder;
using Routine.Features.Reminders.GetReminderById;
using Routine.Features.Reminders.GetReminders;
using Routine.Features.Reminders.UpdateReminder;
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

        [HttpGet("{reminderId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int reminderId, CancellationToken cancellationToken)
        {
            //var userId = (int)HttpContext.Items["UserId"]!;
            // test
            var userId = 1;
            var result = await _mediator.Send(new GetReminderByIdQuery(userId, reminderId), cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReminderDto dto, CancellationToken cancellationToken)
        {
            //var userId = (int)HttpContext.Items["UserId"]!;

            // test 
            var userId = 1;
            var reminderId = await _mediator.Send(new CreateReminderCommand(userId, dto), cancellationToken);
            return CreatedAtAction(nameof(GetById), new { reminderId = reminderId }, new { id = reminderId });
        }

        [HttpPut("{reminderId:int}")]
        public async Task<IActionResult> Update([FromRoute] int reminderId, [FromBody] UpdateReminderDto dto, CancellationToken cancellationToken)
        {
            //var userId = (int)HttpContext.Items["UserId"]!;

            // test
            var userId = 1;
            await _mediator.Send(new UpdateReminderCommand(userId, reminderId, dto), cancellationToken);
            return NoContent();
        }

        [HttpDelete("{reminderId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int reminderId, CancellationToken cancellationToken)
        {
            //var userId = (int)HttpContext.Items["UserId"]!;
            // test
            var userId = 1;
            await _mediator.Send(new DeleteReminderCommand(userId, reminderId), cancellationToken);
            return NoContent();
        }
    }
}