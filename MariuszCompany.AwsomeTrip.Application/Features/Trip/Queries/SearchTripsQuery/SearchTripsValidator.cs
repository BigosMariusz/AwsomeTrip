﻿using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.SearchTripsQuery
{
    public class GetPlayersListValidator : AbstractValidator<SearchTripsQuery>
    {
        public GetPlayersListValidator()
        {
            RuleFor(p => p.Country)
                .NotEmpty()
                .WithMessage("Country is required.")
                .MaximumLength(20)
                .WithMessage("Country maximum length is 20.");

            RuleFor(p => p.PageNumber)
                .NotNull()
                .WithMessage("PageNumber is required.")
                .Must(x =>
                {
                    if (x != null)
                        return x > 0;

                    return true;
                })
                .WithMessage("PageSize must be > than 0.");

            RuleFor(p => p.PageSize)
                .Must(x =>
                {
                    if (x != null)
                        return x > 0;

                    return true;
                })
                .WithMessage("PageSize must be > than 0.")
                .Must(x =>
                {
                    if (x != null)
                        return x <= 100;

                    return true;
                })
                .WithMessage("PageSize must be <= 100.");
        }
    }
}
