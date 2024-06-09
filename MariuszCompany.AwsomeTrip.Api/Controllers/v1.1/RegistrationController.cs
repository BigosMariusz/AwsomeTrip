using MariuszCompany.AwsomeTrip.Application.Dtos.Registration;
using MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.RegisterForTripCommand;
using MariuszCompany.AwsomeTrip.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MariuszCompany.AwsomeTrip.Api.Controllers
{
    /// <summary>
    /// Register for trip
    /// </summary>
    [Route("api/v1.1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RegistrationController : ControllerBase
    {
        private IMediator _mediator;
        public RegistrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Register for trip
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterForTripDto request)
        {
            var result = await _mediator.Send(new RegisterForTripCommand() { Email = request.Email, TripId = request.TripId });

            return CreatedAtAction(nameof(Register), result);
        }
    }
}
