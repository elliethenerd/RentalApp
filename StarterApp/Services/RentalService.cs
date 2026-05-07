using StarterApp.Database.Data.Repositories;
using StarterApp.Database.Models;

namespace StarterApp.Services;

public class RentalService : IRentalService
{
    private readonly IRentalRepository _repository;

    public RentalService(IRentalRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Rental>> GetAllRentalsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task CreateRentalRequest(Item item)
    {
        var rental = new Rental
        {
            ItemId = item.Id,
            ItemTitle = item.Title,
            BorrowerName = "Test User",
            Status = "Requested"
        };

        await _repository.AddAsync(rental);
    }

    public async Task ApproveRental(Rental rental)
    {
        rental.Status = "Approved";

        await _repository.UpdateAsync(rental);
    }

    public async Task RejectRental(Rental rental)
    {
        rental.Status = "Rejected";

        await _repository.UpdateAsync(rental);
    }
}