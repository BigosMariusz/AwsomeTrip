using MariuszCompany.AwsomeTrip.Application.Exceptions;
using MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories;
using MariuszCompany.AwsomeTrip.Domain.Entities;
using MariuszCompany.AwsomeTrip.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Infrastructure.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly AppDbContext _dbContext;
        public TripRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(Trip trip)
        {
            // This should be based on a unique index, but since the in-memory database does not support them, we make an extra query. 
            if (await NameExistAsync(trip.Name))
            {
                throw new ConflictApiException("Trip with such name already exist. Try another name.");
            }

            await _dbContext.AddAsync(trip);
            await _dbContext.SaveChangesAsync();

            return trip.Id;
        }

        public async Task DeleteAsync(Trip trip)
        {
            _dbContext.Remove(trip);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Guid> EditAsync(Trip trip)
        {
            _dbContext.Update(trip);
            await _dbContext.SaveChangesAsync();

            return trip.Id;
        }

        public async Task<Trip?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Trips.SingleOrDefaultAsync(x => x.Id == id);
        }

        private async Task<bool> NameExistAsync(string name)
        {
            return await _dbContext.Trips.AnyAsync(x => x.Name == name);
        }
    }
}
