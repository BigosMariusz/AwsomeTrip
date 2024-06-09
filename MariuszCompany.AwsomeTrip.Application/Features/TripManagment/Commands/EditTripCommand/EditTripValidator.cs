using FluentValidation;
using MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.EditTripCommand
{
    public class EditTripValidator : AbstractValidator<EditTripCommand>
    {
        public EditTripValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .WithMessage("Id is required.");

            RuleFor(p => p.StartDateUtc)
                .NotNull()
                .WithMessage("StartDateUtc is required.")
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("StartDateUtc must be grater than present time.")
                .LessThan(DateTime.UtcNow.AddYears(100))
                .WithMessage("StartDateUtc must be lower than present time + 100 years.");

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(50)
                .WithMessage("Maximum length of Name is 50.");

            RuleFor(p => p.NumberOfSeats)
                .NotNull()
                .WithMessage("NumberOfSeats is required.")
                .Must(p => p > 0)
                .WithMessage("NumberOfSeats must be > than 0.")
                .Must(p => p <= 1000)
                .WithMessage("NumberOfSeats must be <= than 100.");

            RuleFor(p => p.Country)
                .NotNull()
                .WithMessage("Country is required.")
                .MaximumLength(20)
                .WithMessage("Maximum length of Name is 20.");
        }
    }
}
