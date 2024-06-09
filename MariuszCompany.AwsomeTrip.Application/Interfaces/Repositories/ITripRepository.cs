using MariuszCompany.AwsomeTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories
{
    public interface ITripRepository
    {
        Task<Guid> AddAsync(Trip trip);
        Task<Trip?> GetByIdAsync(Guid id);
        Task<Guid> EditAsync(Trip trip);
        Task DeleteAsync(Trip trip);
    }
}
