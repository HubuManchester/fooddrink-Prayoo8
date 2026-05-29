using maui.Models;
using maui.Services;

namespace maui;

public partial class AddItemPage : ContentPage
{
    public AddItemPage()
    {
        InitializeComponent();
        CategoryPicker.ItemsSource = new List<string>
        {
            "Main Course", "Japanese", "Salad", "Beverage", "Dessert", "Snacks", "Other"
        };
        CategoryPicker.SelectedIndex = 0;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        AccessibilityService.ApplyFontScale(this);
    }

    private async void OnSaveClicked(object? sender, EventArgs e)
    {
        var name = NameEntry.Text?.Trim() ?? string.Empty;
        var category = CategoryPicker.SelectedItem?.ToString() ?? string.Empty;
        var description = DescriptionEditor.Text?.Trim() ?? string.Empty;
        var caloriesText = CaloriesEntry.Text?.Trim() ?? string.Empty;
        var proteinText = ProteinEntry.Text?.Trim() ?? "0";
        var carbsText = CarbsEntry.Text?.Trim() ?? "0";
        var fatText = FatEntry.Text?.Trim() ?? "0";
        var allergy = AllergyEntry.Text?.Trim() ?? string.Empty;
        var tags = TagsEntry.Text?.Trim() ?? string.Empty;

        // Validation
        if (string.IsNullOrWhiteSpace(name))
        {
            ShowValidation("Name cannot be empty.");
            return;
        }
        if (string.IsNullOrWhiteSpace(category))
        {
            ShowValidation("Please select a category.");
            return;
        }
        if (string.IsNullOrWhiteSpace(description))
        {
            ShowValidation("Description cannot be empty.");
            return;
        }
        if (!double.TryParse(caloriesText, out var calories) || calories < 0)
        {
            ShowValidation("Calories must be a non-negative number.");
            return;
        }
        if (!double.TryParse(proteinText, out var protein) || protein < 0)
        {
            ShowValidation("Protein must be a non-negative number.");
            return;
        }
        if (!double.TryParse(carbsText, out var carbs) || carbs < 0)
        {
            ShowValidation("Carbs must be a non-negative number.");
            return;
        }
        if (!double.TryParse(fatText, out var fat) || fat < 0)
        {
            ShowValidation("Fat must be a non-negative number.");
            return;
        }

        ValidationLabel.IsVisible = false;

        var item = new FoodItem
        {
            Name = name,
            Category = category,
            Description = description,
            Calories = calories,
            Protein = protein,
            Carbs = carbs,
            Fat = fat,
            AllergyNote = allergy,
            Tags = tags
        };

        FoodCatalogService.Add(item);
        await DisplayAlertAsync("Success", "Food item has been added.", "OK");
        await Shell.Current.GoToAsync("..");
    }

    private void ShowValidation(string message)
    {
        ValidationLabel.Text = message;
        ValidationLabel.IsVisible = true;
        try { Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(250)); } catch { }
        try { HapticFeedback.Default.Perform(HapticFeedbackType.Click); } catch { }
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
