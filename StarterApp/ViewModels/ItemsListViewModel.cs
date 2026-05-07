using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarterApp.Database.Models;
using StarterApp.Services;

namespace StarterApp.ViewModels;

public partial class ItemsListViewModel : ObservableObject
{
    private readonly IItemService _itemService;
    private readonly IRentalService _rentalService;

    public ObservableCollection<Item> Items { get; set; } = new();

    public ItemsListViewModel(
        IItemService itemService,
        IRentalService rentalService)
    {
        _itemService = itemService;
        _rentalService = rentalService;
    }

    [RelayCommand]
    private async Task LoadItems()
    {
        var items = await _itemService.GetAllItemsAsync();

        Items.Clear();

        foreach (var item in items)
        {
            Items.Add(item);
        }
    }

    [RelayCommand]
    private async Task RequestRental(Item item)
    {
        await _rentalService.CreateRentalRequest(item);

        await Shell.Current.DisplayAlert(
            "Success",
            "Rental requested",
            "OK");
    }
}