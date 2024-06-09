using MariuszCompany.AwsomeTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.SearchTripsQuery
{
    public class SearchTripsVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime StartDateUtc { get; set; }
    }
}
