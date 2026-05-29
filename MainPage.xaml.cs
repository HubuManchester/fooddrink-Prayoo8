namespace maui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnReadTipClicked(object? sender, EventArgs e)
        {
            const string tip = "Try to build your plate with half vegetables, a quarter protein, and a quarter whole grains.";
            await TextToSpeech.SpeakAsync(tip);
            await DisplayAlertAsync("Nutrition Tip", tip, "OK");
        }

        private void OnTextSizeChanged(object? sender, ValueChangedEventArgs e)
        {
            var roundedSize = Math.Round(e.NewValue);
            TextSizeValueLabel.Text = roundedSize.ToString("F0");

            if (Application.Current?.Resources is null)
            {
                return;
            }

            Application.Current.Resources["BodyFontSize"] = roundedSize;
            Application.Current.Resources["TitleFontSize"] = roundedSize + 13;
            Application.Current.Resources["SubTitleFontSize"] = roundedSize + 5;
        }
    }
}
