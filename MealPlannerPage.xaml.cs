using System.Collections.ObjectModel;
using maui.Models;
using maui.Services;

namespace maui;

public partial class MealPlannerPage : ContentPage
{
    private readonly ObservableCollection<MealPlanItem> _mealPlans = new();
    private readonly MealPlannerService _mealPlannerService = new();

    public MealPlannerPage()
    {
        InitializeComponent();

        MealTypePicker.ItemsSource = new List<string> { "Breakfast", "Lunch", "Dinner", "Snack" };
        MealTypePicker.SelectedIndex = 0;
        MealDatePicker.Date = DateTime.Today;
        MealCollectionView.ItemsSource = _mealPlans;
    }

    private async void OnAddMealClicked(object? sender, EventArgs e)
    {
        var mealType = MealTypePicker.SelectedItem?.ToString() ?? string.Empty;

        var isValid = _mealPlannerService.TryCreateMealPlanItem(
            mealType,
            MealNameEntry.Text ?? string.Empty,
            CaloriesEntry.Text ?? string.Empty,
            MealDatePicker.Date ?? DateTime.Today,
            NotesEditor.Text,
            out var item,
            out var errorMessage);

        if (!isValid || item is null)
        {
            ValidationLabel.Text = errorMessage;
            ValidationLabel.IsVisible = true;
            await DisplayAlertAsync("Validation Error", errorMessage, "OK");
            SemanticScreenReader.Announce(errorMessage);
            return;
        }

        ValidationLabel.IsVisible = false;
        _mealPlans.Add(item);

        var totalCalories = _mealPlannerService.CalculateTotalCalories(_mealPlans);
        CaloriesSummaryLabel.Text = $"Total planned calories: {totalCalories}";

        MealNameEntry.Text = string.Empty;
        CaloriesEntry.Text = string.Empty;
        NotesEditor.Text = string.Empty;

        await DisplayAlertAsync("Success", "Meal added to planner.", "OK");
    }
}
