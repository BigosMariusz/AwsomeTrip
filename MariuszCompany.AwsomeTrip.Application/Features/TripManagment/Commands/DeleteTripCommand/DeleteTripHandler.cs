using AutoMapper;
using MariuszCompany.AwsomeTrip.Application.Exceptions;
using MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories;
using MariuszCompany.AwsomeTrip.Application.Responses;
using MariuszCompany.AwsomeTrip.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.DeleteTripCommand
{
    public class DeleteTripHandler : IRequestHandler<DeleteTripCommand>
    {
        private readonly ITripRepository _tripRepository;
        public DeleteTripHandler(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task Handle(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            var dbTrip = await _tripRepository.GetByIdAsync(request.Id.Value);
            if (dbTrip is null)
            {
                throw new NotFoundApiException();
            }

            await _tripRepository.DeleteAsync(dbTrip);
        }
    }
}
