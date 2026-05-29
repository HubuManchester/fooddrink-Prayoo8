namespace maui.Services;

public static class SpeechService
{
    public static async Task SpeakAsync(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return;
        Stop();
        var locales = await TextToSpeech.Default.GetLocalesAsync();
        var chinese = locales.FirstOrDefault(l => l.Language?.StartsWith("zh", StringComparison.OrdinalIgnoreCase) == true);
        var options = new SpeechOptions
        {
            Volume = 0.9f,
            Pitch = 1.08f,
            Locale = chinese
        };
        await TextToSpeech.Default.SpeakAsync(text, options);
    }

    public static void Stop()
    {
        TextToSpeech.Default.Cancel();
    }
}
