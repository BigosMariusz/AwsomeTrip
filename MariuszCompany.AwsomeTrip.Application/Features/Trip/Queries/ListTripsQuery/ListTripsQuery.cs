using AutoMapper;
using MariuszCompany.AwsomeTrip.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.ListTripsQuery
{
    public class ListTripsQuery : IRequest<PagedResponse<IEnumerable<ListTripsVM>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
