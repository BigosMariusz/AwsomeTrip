using FluentValidation;
using MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.DeleteTripCommand
{
    public class DeleteTripValidator : AbstractValidator<DeleteTripCommand>
    {
        public DeleteTripValidator()
        {

            RuleFor(p => p.Id)
                .NotNull()
                .WithMessage("Id is required.");
        }
    }
}
