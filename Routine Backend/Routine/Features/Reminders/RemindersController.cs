using MediatR;
using Microsoft.AspNetCore.Mvc;
using Routine.Features.Reminders.GetReminders;

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
        public async Task<IActionResult> GetByUserId([FromQuery] int userId,CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetRemindersQuery(userId),cancellationToken);

            return Ok(result);
        }
    }
}