using MariuszCompany.AwsomeTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories
{
    public interface IRegistrationRepository
    {
        Task<Guid> RegisterForTripAsync(Registration registration);
    }
}
