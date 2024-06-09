using AutoMapper;
using MariuszCompany.AwsomeTrip.Application.Exceptions;
using MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories;
using MariuszCompany.AwsomeTrip.Application.Responses;
using MariuszCompany.AwsomeTrip.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.EditTripCommand
{
    public class EditTripHandler : IRequestHandler<EditTripCommand, Guid>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        public EditTripHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(EditTripCommand request, CancellationToken cancellationToken)
        {
            var dbTrip = await _tripRepository.GetByIdAsync(request.Id.Value);
            if (dbTrip is null)
            {
                throw new NotFoundApiException();
            }

            _mapper.Map(request, dbTrip);
            return await _tripRepository.EditAsync(dbTrip);
        }
    }
}
