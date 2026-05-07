using System.Collections.Generic;
using System.Threading.Tasks;
using StarterApp.Database.Models;
using StarterApp.Database.Data.Repositories;

namespace StarterApp.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
            return await _itemRepository.GetAllAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _itemRepository.GetByIdAsync(id);
        }

        public async Task CreateItemAsync(Item item)
        {
            // basic business logic (you can mention this in your report 👀)
            if (item.DailyRate < 0)
                throw new System.Exception("Daily rate must be positive");

            await _itemRepository.AddAsync(item);
        }
    }
}