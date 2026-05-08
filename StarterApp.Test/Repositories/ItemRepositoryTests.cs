using StarterApp.Database.Data.Repositories;
using StarterApp.Database.Models;
using Xunit;

namespace StarterApp.Test.Repositories;

public class ItemRepositoryTests
{
    [Fact]
    public async Task AddAsync_AddsItemToRepository()
    {
        // Arrange
        var repository = new ItemRepository();

        var item = new Item
        {
            Title = "Laptop",
            Description = "Renting for studying",
            DailyRate = 30,
            Category = "Technology"
        };

        // Act
        await repository.AddAsync(item);

        var items = await repository.GetAllAsync();

        // Assert
        Assert.Single(items);
    }
}