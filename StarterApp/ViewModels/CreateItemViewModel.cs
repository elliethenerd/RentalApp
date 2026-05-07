using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarterApp.Database.Models;
using StarterApp.Services;

namespace StarterApp.ViewModels;

public partial class CreateItemViewModel : ObservableObject
{
    private readonly IItemService _itemService;

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private string description;

    [ObservableProperty]
    private decimal dailyRate;

    public CreateItemViewModel(IItemService itemService)
    {
        _itemService = itemService;
    }

    [RelayCommand]
    private async Task SaveItem()
    {
        var item = new Item
        {
            Title = Title,
            Description = Description,
            DailyRate = DailyRate,
            Category = "General"
        };

        await _itemService.CreateItemAsync(item);

        await Shell.Current.GoToAsync("..");
    }
}