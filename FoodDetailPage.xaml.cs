using maui.Models;
using maui.Services;

namespace maui;

[QueryProperty(nameof(FoodItem), "FoodItem")]
public partial class FoodDetailPage : ContentPage
{
    private FoodItem? _foodItem;
    public FoodItem? FoodItem
    {
        get => _foodItem;
        set
        {
            _foodItem = value;
            if (value != null) BindFoodItem(value);
        }
    }

    public FoodDetailPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        AccessibilityService.ApplyFontScale(this);
    }

    private void BindFoodItem(FoodItem item)
    {
        NameLabel.Text = item.Name;
        CategoryLabel.Text = item.Category;
        CaloriesLabel.Text = $"Calories: {item.CaloriesLabel}";
        ProteinLabel.Text = $"Protein: {item.Protein} g";
        CarbsLabel.Text = $"Carbs: {item.Carbs} g";
        FatLabel.Text = $"Fat: {item.Fat} g";
        DescriptionLabel.Text = item.Description;
        AllergyLabel.Text = string.IsNullOrWhiteSpace(item.AllergyNote) ? "None" : item.AllergyNote;
    }

    private async void OnSpeakClicked(object? sender, EventArgs e)
    {
        if (_foodItem == null) return;
        await SpeechService.SpeakAsync(_foodItem.AccessibleSummary);
    }

    private void OnStopClicked(object? sender, EventArgs e)
    {
        SpeechService.Stop();
    }

    private void OnVibrateClicked(object? sender, EventArgs e)
    {
        try
        {
            Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(250));
            HapticFeedback.Default.Perform(HapticFeedbackType.Click);
        }
        catch (FeatureNotSupportedException)
        {
            DisplayAlertAsync("Not Supported", "Vibration is not available on this device.", "OK");
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        SpeechService.Stop();
    }
}