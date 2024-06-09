using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.GetSingleTripQuery
{
    public class GetSingleTripValidator : AbstractValidator<GetSingleTripQuery>
    {
        public GetSingleTripValidator()
        {
            RuleFor(p => p.TripId)
                .NotNull()
                .WithMessage("TripId is required.");
        }
    }
}
