namespace maui.Services;

public static class SpeechService
{
    private static CancellationTokenSource? _cts;

    public static async Task SpeakAsync(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return;
        Stop();
        _cts = new CancellationTokenSource();
        var locales = await TextToSpeech.Default.GetLocalesAsync();
        var chinese = locales.FirstOrDefault(l => l.Language?.StartsWith("zh", StringComparison.OrdinalIgnoreCase) == true);
        var options = new SpeechOptions
        {
            Volume = 0.9f,
            Pitch = 1.08f,
            Locale = chinese
        };
        try
        {
            await TextToSpeech.Default.SpeakAsync(text, options, _cts.Token);
        }
        catch (OperationCanceledException)
        {
            // Speech was cancelled, ignore
        }
    }

    public static void Stop()
    {
        if (_cts != null && !_cts.IsCancellationRequested)
        {
            _cts.Cancel();
            _cts.Dispose();
            _cts = null;
        }
    }
}
