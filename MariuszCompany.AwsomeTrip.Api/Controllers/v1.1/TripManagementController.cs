using MariuszCompany.AwsomeTrip.Application.Dtos.TripsManagment;
using MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.CreateTripCommand;
using MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.DeleteTripCommand;
using MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.EditTripCommand;
using MariuszCompany.AwsomeTrip.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MariuszCompany.AwsomeTrip.Api.Controllers
{
    /// <summary>
    /// Create, edit and delete trips
    /// </summary>
    [Route("api/v1.1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TripManagementController : ControllerBase
    {
        private IMediator _mediator;
        public TripManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create new trip
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateTrip([FromBody] CreateTripDto request)
        {
            var result = await _mediator.Send(new CreateTripCommand()
                {
                    Country = request.Country,
                    NumberOfSeats = request.NumberOfSeats,
                    Name = request.Name,
                    StartDateUtc = request.StartDateUtc,
                    Description = request.Description
                }
            );

            return CreatedAtAction(nameof(CreateTrip), result);
        }

        /// <summary>
        /// Edit existing trip
        /// </summary>
        /// <param name="tripId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("edit/{tripId}")]
        [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditTrip([FromRoute] Guid? tripId, [FromBody] EditTripDto request)
        {
            await _mediator.Send(new EditTripCommand()
                {
                    Country = request.Country,
                    NumberOfSeats = request.NumberOfSeats,
                    Name = request.Name,
                    StartDateUtc = request.StartDateUtc,
                    Description = request.Description,
                    Id = tripId
                }
            );

            return NoContent();
        }

        /// <summary>
        /// Delete existing trip
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        [HttpDelete("delete/{tripId}")]
        [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTrip([FromRoute] Guid? tripId)
        {
            await _mediator.Send(new DeleteTripCommand() { Id = tripId });

            return NoContent();
        }
    }
}
