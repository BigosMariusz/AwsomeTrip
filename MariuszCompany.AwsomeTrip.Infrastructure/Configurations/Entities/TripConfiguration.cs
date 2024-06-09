using MariuszCompany.AwsomeTrip.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace MariuszCompany.AwsomeTrip.Infrastructure.Configurations.Entities;
public class TripConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.ToTable("Trips");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.HasIndex(t => t.Name).IsUnique();

        builder.Property(x => x.Country).IsRequired();
        builder.Property(x => x.Country).HasMaxLength(20);
        builder.HasIndex(e => e.Country);
    }
}
