using maui.Services;

namespace maui;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
        ThemePicker.ItemsSource = new List<string> { "Follow System", "Light Theme", "Dark Theme" };
        ThemePicker.SelectedIndex = 0;
        LargeFontSwitch.IsToggled = AccessibilityService.LargeTextEnabled;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        AccessibilityService.ApplyFontScale(this);
    }

    private void OnThemeChanged(object? sender, EventArgs e)
    {
        if (Application.Current == null) return;
        switch (ThemePicker.SelectedIndex)
        {
            case 0:
                Application.Current.UserAppTheme = AppTheme.Unspecified;
                break;
            case 1:
                Application.Current.UserAppTheme = AppTheme.Light;
                break;
            case 2:
                Application.Current.UserAppTheme = AppTheme.Dark;
                break;
        }
    }

    private void OnLargeFontToggled(object? sender, ToggledEventArgs e)
    {
        AccessibilityService.LargeTextEnabled = e.Value;
        AccessibilityService.ApplyFontScale(this);
    }
}
