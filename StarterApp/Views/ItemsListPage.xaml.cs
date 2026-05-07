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

    private async void GoToCreateItemPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(
            new CreateItemPage(
                new CreateItemViewModel(
                    Handler.MauiContext.Services.GetService<IItemService>())));
    }
}