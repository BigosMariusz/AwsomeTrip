using AutoMapper;
using MariuszCompany.AwsomeTrip.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.SearchTripsQuery
{
    public class SearchTripsQuery : IRequest<PagedResponse<IEnumerable<SearchTripsVM>>>
    {
        public string? Country { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
