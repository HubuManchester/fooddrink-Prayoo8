namespace maui.Services;

public static class AccessibilityService
{
    private static bool _largeTextEnabled;
    private static readonly double _defaultScale = 1.0;
    private static readonly double _largeScale = 1.4;

    public static bool LargeTextEnabled
    {
        get => _largeTextEnabled;
        set => _largeTextEnabled = value;
    }

    public static void ApplyFontScale(ContentPage page)
    {
        var scale = _largeTextEnabled ? _largeScale : _defaultScale;
        if (Application.Current?.Resources != null)
        {
            var baseSize = _largeTextEnabled ? 21.0 : 15.0;
            Application.Current.Resources["BodyFontSize"] = baseSize;
            Application.Current.Resources["TitleFontSize"] = baseSize + 13;
            Application.Current.Resources["SubTitleFontSize"] = baseSize + 5;
        }
    }
}
