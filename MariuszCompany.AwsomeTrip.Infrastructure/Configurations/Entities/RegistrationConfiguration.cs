using MariuszCompany.AwsomeTrip.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace MariuszCompany.AwsomeTrip.Infrastructure.Configurations.Entities;
public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        builder.ToTable("Registrations");

        builder.HasKey(x => x.Id);

        builder.HasOne(m => m.Trip)
            .WithMany(t => t.Registrations)
            .HasForeignKey(m => m.TripId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Email).IsRequired();

        builder.HasIndex(r => new { r.Email, r.TripId }).IsUnique();
    }
}
