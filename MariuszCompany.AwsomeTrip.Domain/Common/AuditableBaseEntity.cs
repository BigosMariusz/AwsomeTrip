namespace MariuszCompany.AwsomeTrip.Domain.Common
{
    public abstract class AuditableBaseEntity : IdentitableEntity
    {
        public DateTime DateCreatedUtc { get; set; }
        public DateTime DateModifiedUtc { get; set; }
    }
}
