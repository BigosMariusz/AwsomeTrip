using MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.GetSingleTripQuery;
using MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.ListTripsQuery;
using MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.SearchTripsQuery;
using MariuszCompany.AwsomeTrip.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MariuszCompany.AwsomeTrip.Api.Controllers
{
    /// <summary>
    /// List, search or get single trip
    /// </summary>
    [Route("api/v1.1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TripController : ControllerBase
    {
        private IMediator _mediator;
        public TripController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Search trips and filter by country with pagination
        /// </summary>
        /// <param name="country"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("search")]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<SearchTripsVM>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Search(string? country, int? pageNumber, int? pageSize)
        {
            var result = await _mediator.Send(new SearchTripsQuery() { Country = country, PageNumber = pageNumber, PageSize = pageSize });

            return Ok(result);
        }

        /// <summary>
        /// List all trips with pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<SearchTripsVM>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetList(int? pageNumber, int? pageSize)
        {
            var result = await _mediator.Send(new ListTripsQuery() { PageNumber = pageNumber, PageSize = pageSize });

            return Ok(result);
        }

        /// <summary>
        /// Get single trip
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        [HttpGet("{tripId}")]
        [ProducesResponseType(typeof(Response<SearchTripsVM>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSingle([FromRoute] Guid? tripId)
        {
            var result = await _mediator.Send(new GetSingleTripQuery() { TripId = tripId });

            return Ok(result);
        }
    }
}
