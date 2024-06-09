using AutoMapper;
using MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories;
using MariuszCompany.AwsomeTrip.Application.Responses;
using MariuszCompany.AwsomeTrip.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.CreateTripCommand
{
    public class CreateTripHandler : IRequestHandler<CreateTripCommand, Response<Guid>>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        public CreateTripHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var trip = _mapper.Map<Domain.Entities.Trip>(request);
            await _tripRepository.AddAsync(trip);

            return new Response<Guid>(trip.Id);
        }
    }
}
