using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarterApp.Database.Models;
using StarterApp.Services;

namespace StarterApp.ViewModels
{
    public partial class ItemsListViewModel : ObservableObject
    {
        private readonly IItemService _itemService;

        public ObservableCollection<Item> Items { get; set; } = new();

        public ItemsListViewModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        [RelayCommand]
        public async Task LoadItems()
        {
            var items = await _itemService.GetAllItemsAsync();

            Items.Clear();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}