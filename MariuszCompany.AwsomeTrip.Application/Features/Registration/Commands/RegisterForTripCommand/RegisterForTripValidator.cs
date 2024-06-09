using FluentValidation;
using MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.RegisterForTripCommand
{
    public class RegisterForTripValidator : AbstractValidator<RegisterForTripCommand>
    {
        public RegisterForTripValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Wrong email format.")
                .MaximumLength(254)
                .WithMessage("Email max length is 254.");

            RuleFor(p => p.TripId)
                .NotNull()
                .WithMessage("TripId is required.");
        }
    }
}
