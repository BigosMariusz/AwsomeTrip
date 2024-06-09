using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Application.Dtos.Registration
{
    public class RegisterForTripDto
    {
        public string? Email { get; set; }
        public Guid? TripId { get; set; }
    }
}
