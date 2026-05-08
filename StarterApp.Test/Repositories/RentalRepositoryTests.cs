using StarterApp.Database.Data.Repositories;
using StarterApp.Database.Models;
using Xunit;

namespace StarterApp.Test.Repositories;

public class RentalRepositoryTests
{
    [Fact]
    public async Task AddAsync_AddsRentalToRepository()
    {
        // Arrange
        var repository = new RentalRepository();

        var rental = new Rental
        {
            ItemId = 1,
            ItemTitle = "Drill",
            BorrowerName = "Ellie",
            Status = "Requested"
        };

        // Act
        await repository.AddAsync(rental);

        var rentals = await repository.GetAllAsync();

        // Assert
        Assert.Single(rentals);
    }
}