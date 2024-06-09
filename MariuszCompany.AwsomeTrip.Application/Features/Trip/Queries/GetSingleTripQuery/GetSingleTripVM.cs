using MariuszCompany.AwsomeTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.GetSingleTripQuery
{
    public class GetSingleTripVM
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public byte NumberOfSeats { get; set; }
        public DateTime StartDateUtc { get; set; }
    }
}
