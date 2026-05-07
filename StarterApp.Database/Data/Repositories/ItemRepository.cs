using StarterApp.Database.Models;

namespace StarterApp.Database.Data.Repositories;

public class ItemRepository : IItemRepository
{
    private static readonly List<Item> _items = new();

    public async Task<List<Item>> GetAllAsync()
    {
        return await Task.FromResult(_items);
    }

    public async Task<Item?> GetByIdAsync(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);

        return await Task.FromResult(item);
    }

    public async Task AddAsync(Item item)
    {
        item.Id = _items.Count + 1;

        _items.Add(item);

        await Task.CompletedTask;
    }
}