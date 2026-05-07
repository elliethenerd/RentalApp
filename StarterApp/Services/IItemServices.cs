using System.Collections.Generic;
using System.Threading.Tasks;
using StarterApp.Database.Models;

namespace StarterApp.Services
{
    public interface IItemService
    {
        Task<List<Item>> GetAllItemsAsync();
        Task<Item> GetItemByIdAsync(int id);
        Task CreateItemAsync(Item item);
    }
}