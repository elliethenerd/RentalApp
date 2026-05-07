using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarterApp.Database.Models;
using StarterApp.Services;

namespace StarterApp.ViewModels;

public partial class RentalsViewModel : ObservableObject
{
    private readonly IRentalService _rentalService;

    public ObservableCollection<Rental> Rentals { get; set; } = new();

    public RentalsViewModel(IRentalService rentalService)
    {
        _rentalService = rentalService;
    }

    [RelayCommand]
    private async Task LoadRentals()
    {
        var rentals = await _rentalService.GetAllRentalsAsync();

        Rentals.Clear();

        foreach (var rental in rentals)
        {
            Rentals.Add(rental);
        }
    }

    [RelayCommand]
    private async Task ApproveRental(Rental rental)
    {
        await _rentalService.ApproveRental(rental);

        await Shell.Current.DisplayAlert(
            "Success",
            "Rental approved",
            "OK");

        await LoadRentals();
    }

    [RelayCommand]
    private async Task RejectRental(Rental rental)
    {
        await _rentalService.RejectRental(rental);

        await Shell.Current.DisplayAlert(
            "Success",
            "Rental rejected",
            "OK");

        await LoadRentals();
    }
}