
using MariuszCompany.AwsomeTrip.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MariuszCompany.AwsomeTrip.Domain.Entities
{
    public class Trip : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public DateTime StartDateUtc { get; set; }
        public byte NumberOfSeats { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
