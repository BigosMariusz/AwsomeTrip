
using MariuszCompany.AwsomeTrip.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MariuszCompany.AwsomeTrip.Domain.Entities
{
    public class Registration : AuditableBaseEntity
    {
        public string Email { get; set; }
        public Guid TripId { get; set; }
        public Trip Trip { get; set; }
    }
}
