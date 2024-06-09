using AutoMapper;
using MariuszCompany.AwsomeTrip.Application.Exceptions;
using MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories;
using MariuszCompany.AwsomeTrip.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.GetSingleTripQuery
{
    public class GetSingleTripHandler : IRequestHandler<GetSingleTripQuery, Response<GetSingleTripVM>>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        public GetSingleTripHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetSingleTripVM>> Handle(GetSingleTripQuery request, CancellationToken cancellationToken)
        {
            var trip = await _tripRepository.GetByIdAsync(request.TripId.Value);
            if (trip == null)
            {
                throw new NotFoundApiException();
            }

            var vm = _mapper.Map<GetSingleTripVM>(trip);

            return new Response<GetSingleTripVM>(vm);
        }
    }
}
