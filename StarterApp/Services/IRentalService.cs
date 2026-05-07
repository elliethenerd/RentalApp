using StarterApp.Database.Models;

namespace StarterApp.Services;

public interface IRentalService
{
    Task<List<Rental>> GetAllRentalsAsync();

    Task CreateRentalRequest(Item item);

    Task ApproveRental(Rental rental);

    Task RejectRental(Rental rental);
}