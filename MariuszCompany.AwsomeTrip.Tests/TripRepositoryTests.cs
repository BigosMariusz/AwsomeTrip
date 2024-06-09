using MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories;
using MariuszCompany.AwsomeTrip.Domain.Entities;
using MariuszCompany.AwsomeTrip.Infrastructure.DbContexts;
using MariuszCompany.AwsomeTrip.Infrastructure.Repositories;
using Moq;

namespace MariuszCompany.AwsomeTrip.Tests
{
    public class TripRepositoryTests
    {
        private readonly Mock<AppDbContext> _mockContext;
        private readonly TripRepository _tripRepository;

        public TripRepositoryTests()
        {
            _mockContext = new Mock<AppDbContext>();
            _tripRepository = new TripRepository(_mockContext.Object);
        }

        [Fact]
        public async Task AddAsync_Should_Call_AddAsync_And_SaveChanges()
        {
            var item = new Trip
            {
                Country = "Poland",
                Name = "My trip",
                NumberOfSeats = 30,
            };

            await _tripRepository.AddAsync(item);

            _mockContext.Verify(m => m.Trips.AddAsync(item, It.IsAny<CancellationToken>()), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Correct_Trip()
        {
            var trip = new Trip
            {
                Country = "USA",
                Name = "My trip",
                NumberOfSeats = 30,
            };

            var id = Guid.NewGuid();

            _mockContext.Setup(m => m.Trips.FindAsync(id)).ReturnsAsync(trip);

            var result = await _tripRepository.GetByIdAsync(id);

            Assert.NotNull(result);
            Assert.Equal("My trip", result.Name);
        }

        [Fact]
        public async Task UpdateAsync_Should_Call_Update_And_SaveChanges()
        {
            var trip = new Trip
            {
                Country = "Canada",
                Name = "My trip",
                NumberOfSeats = 30,
            };

            await _tripRepository.EditAsync(trip);

            _mockContext.Verify(m => m.Trips.Update(trip), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_Should_Call_Remove_And_SaveChanges()
        {
            var trip = new Trip
            {
                Country = "Germany",
                Name = "My trip",
                NumberOfSeats = 30,
            };

            var id = Guid.NewGuid();

            _mockContext.Setup(m => m.Trips.FindAsync(id)).ReturnsAsync(trip);

            await _tripRepository.DeleteAsync(trip);

            _mockContext.Verify(m => m.Trips.Remove(trip), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

    }
}
