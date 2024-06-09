using AutoMapper;
using MariuszCompany.AwsomeTrip.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.GetSingleTripQuery
{
    public class GetSingleTripQuery : IRequest<Response<GetSingleTripVM>>
    {
        public Guid? TripId { get; set; }
    }
}
