using MariuszCompany.AwsomeTrip.Application.Exceptions;
using MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories;
using MariuszCompany.AwsomeTrip.Domain.Entities;
using MariuszCompany.AwsomeTrip.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Infrastructure.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly AppDbContext _dbContext;
        public RegistrationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> RegisterForTripAsync(Registration registration)
        {
            // This should be based on a unique index, but since the in-memory database does not support them, we make an extra query. 
            if (await UserAlreadyRegisteredAsync(registration.Email, registration.TripId))
            {
                throw new ConflictApiException("This email is already registered for this trip.");
            }

            await _dbContext.AddAsync(registration);
            await _dbContext.SaveChangesAsync();

            return registration.Id;
        }

        private async Task<bool> UserAlreadyRegisteredAsync(string email, Guid tripId)
        {
            return await _dbContext.Registrations.AnyAsync(x => x.Email == email && x.TripId == tripId);
        }
    }
}
