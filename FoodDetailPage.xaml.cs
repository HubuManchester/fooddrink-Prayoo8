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
        CaloriesLabel.Text = $"热量：{item.CaloriesLabel}";
        ProteinLabel.Text = $"蛋白质：{item.Protein} 克";
        CarbsLabel.Text = $"碳水化合物：{item.Carbs} 克";
        FatLabel.Text = $"脂肪：{item.Fat} 克";
        DescriptionLabel.Text = item.Description;
        AllergyLabel.Text = string.IsNullOrWhiteSpace(item.AllergyNote) ? "无" : item.AllergyNote;
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
            DisplayAlertAsync("不支持", "当前设备不支持震动功能。", "OK");
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        SpeechService.Stop();
    }
}