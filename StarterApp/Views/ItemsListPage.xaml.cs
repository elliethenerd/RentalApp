using StarterApp.ViewModels;
using StarterApp.Services;

namespace StarterApp.Views;

public partial class ItemsListPage : ContentPage
{
    public ItemsListPage(ItemsListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ItemsListViewModel vm)
        {
            await vm.LoadItemsCommand.ExecuteAsync(null);
        }
    }

    private async void GoToCreateItemPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(
            new CreateItemPage(
                new CreateItemViewModel(
                    Handler.MauiContext.Services.GetService<IItemService>())));
    }

    private async void GoToRentalsPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(
            Handler.MauiContext.Services.GetService<RentalsPage>());
    }
}