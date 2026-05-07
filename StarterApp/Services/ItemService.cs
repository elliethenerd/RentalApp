using StarterApp.Database.Data.Repositories;
using StarterApp.Database.Models;

namespace StarterApp.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _repository;

    public ItemService(IItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Item>> GetAllItemsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Item?> GetItemByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CreateItemAsync(Item item)
    {
        await _repository.AddAsync(item);
    }
}