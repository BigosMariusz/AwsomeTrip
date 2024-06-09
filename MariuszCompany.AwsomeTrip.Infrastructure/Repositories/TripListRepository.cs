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
    public class TripListRepository : ITripListRepository
    {
        private readonly AppDbContext _dbContext;
        public TripListRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<Trip>> GetList(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Trips
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IReadOnlyCollection<Trip>> SearchByCountry(string country, int pageNumber, int pageSize)
        {
            var query = _dbContext
                .Trips
                .AsNoTracking();

            if (country != null)
            {
                query = query.Where(x => x.Country.Contains(country));
            }

            return await query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
