using AutoMapper;
using MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories;
using MariuszCompany.AwsomeTrip.Application.Responses;
using MariuszCompany.AwsomeTrip.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.RegisterForTripCommand
{
    public class RegisterForTripHandler : IRequestHandler<RegisterForTripCommand, Response<Guid>>
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IMapper _mapper;
        public RegisterForTripHandler(IRegistrationRepository registrationRepository, IMapper mapper)
        {
            _registrationRepository = registrationRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(RegisterForTripCommand request, CancellationToken cancellationToken)
        {
            var registration = _mapper.Map<Registration>(request);
            await _registrationRepository.RegisterForTripAsync(registration);

            return new Response<Guid>(registration.Id);
        }
    }
}
