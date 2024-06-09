using MariuszCompany.AwsomeTrip.Domain.Common;
using MariuszCompany.AwsomeTrip.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MariuszCompany.AwsomeTrip.Infrastructure.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public AppDbContext()
        {

        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DateCreatedUtc = DateTime.UtcNow;
                        entry.Entity.DateModifiedUtc = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.DateModifiedUtc = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
