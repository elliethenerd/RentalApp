using StarterApp.Database.Models;

namespace StarterApp.Database.Data.Repositories;

public class RentalRepository : IRentalRepository
{
    private static readonly List<Rental> _rentals = new();

    public async Task<List<Rental>> GetAllAsync()
    {
        return await Task.FromResult(_rentals);
    }

    public async Task AddAsync(Rental rental)
    {
        rental.Id = _rentals.Count + 1;

        _rentals.Add(rental);

        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Rental rental)
    {
        await Task.CompletedTask;
    }
}