using MariuszCompany.AwsomeTrip.Domain.Entities;

namespace MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories
{
    public interface ITripListRepository
    {
        Task<IReadOnlyCollection<Trip>> SearchByCountry(string country, int pageNumber, int pageSize);
        Task<IReadOnlyCollection<Trip>> GetList(int pageNumber, int pageSize);
    }
}