using maui.Models;
using maui.Services;

namespace maui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        LoadFoods();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Services.AccessibilityService.ApplyFontScale(this);
        LoadFoods();
    }

    private void LoadFoods()
    {
        var foods = FoodCatalogService.GetAll();
        FoodCollectionView.ItemsSource = foods;
    }

    private void OnSearchButtonPressed(object? sender, EventArgs e)
    {
        var query = FoodSearchBar.Text ?? string.Empty;
        FoodCollectionView.ItemsSource = FoodCatalogService.Search(query);
    }

    private void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
    {
        var query = e.NewTextValue ?? string.Empty;
        if (string.IsNullOrWhiteSpace(query))
        {
            LoadFoods();
        }
        else
        {
            FoodCollectionView.ItemsSource = FoodCatalogService.Search(query);
        }
    }

    private async void OnRefreshing(object? sender, EventArgs e)
    {
        await Task.Delay(500);
        LoadFoods();
        RefreshView.IsRefreshing = false;
    }

    private async void OnFoodSelected(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is FoodItem item)
        {
            FoodCollectionView.SelectedItem = null;
            await Shell.Current.GoToAsync(nameof(FoodDetailPage), new Dictionary<string, object>
            {
                { "FoodItem", item }
            });
        }
    }

    private async void OnAddFoodClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddItemPage));
    }
}
