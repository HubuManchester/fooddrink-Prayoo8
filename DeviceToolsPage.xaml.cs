namespace maui;

public partial class DeviceToolsPage : ContentPage
{
    public DeviceToolsPage()
    {
        InitializeComponent();
    }

    private async void OnTakePhotoClicked(object? sender, EventArgs e)
    {
        try
        {
            if (!MediaPicker.Default.IsCaptureSupported)
            {
                await DisplayAlertAsync("Not Supported", "Camera capture is not supported on this device.", "OK");
                return;
            }

            var photo = await MediaPicker.Default.CapturePhotoAsync();
            if (photo is null)
            {
                PhotoStatusLabel.Text = "Photo: canceled";
                return;
            }

            PhotoStatusLabel.Text = $"Photo captured: {photo.FileName}";
        }
        catch (PermissionException)
        {
            await DisplayAlertAsync("Permission Required", "Camera permission is required to take food photos.", "OK");
        }
        catch (Exception)
        {
            await DisplayAlertAsync("Error", "Unable to capture photo right now.", "OK");
        }
    }

    private async void OnGetLocationClicked(object? sender, EventArgs e)
    {
        try
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            if (status != PermissionStatus.Granted)
            {
                await DisplayAlertAsync("Permission Required", "Location permission is required.", "OK");
                return;
            }

            var location = await Geolocation.Default.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10)));
            if (location is null)
            {
                LocationStatusLabel.Text = "Location: unavailable";
                return;
            }

            LocationStatusLabel.Text = $"Location: {location.Latitude:F4}, {location.Longitude:F4}";
        }
        catch (FeatureNotSupportedException)
        {
            await DisplayAlertAsync("Not Supported", "Location is not supported on this device.", "OK");
        }
        catch (Exception)
        {
            await DisplayAlertAsync("Error", "Unable to get location right now.", "OK");
        }
    }

    private void OnStartAccelerometerClicked(object? sender, EventArgs e)
    {
        if (Accelerometer.Default.IsMonitoring)
        {
            return;
        }

        Accelerometer.Default.ReadingChanged += OnAccelerometerReadingChanged;
        Accelerometer.Default.Start(SensorSpeed.UI);
        AccelerometerStatusLabel.Text = "Accelerometer: running";
    }

    private void OnStopAccelerometerClicked(object? sender, EventArgs e)
    {
        if (!Accelerometer.Default.IsMonitoring)
        {
            return;
        }

        Accelerometer.Default.Stop();
        Accelerometer.Default.ReadingChanged -= OnAccelerometerReadingChanged;
        AccelerometerStatusLabel.Text = "Accelerometer: stopped";
    }

    private void OnAccelerometerReadingChanged(object? sender, AccelerometerChangedEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            AccelerometerStatusLabel.Text = $"Accelerometer: X {e.Reading.Acceleration.X:F2}, Y {e.Reading.Acceleration.Y:F2}, Z {e.Reading.Acceleration.Z:F2}";
        });
    }

    private void OnStartCompassClicked(object? sender, EventArgs e)
    {
        if (Compass.Default.IsMonitoring)
        {
            return;
        }

        Compass.Default.ReadingChanged += OnCompassReadingChanged;
        Compass.Default.Start(SensorSpeed.UI);
        CompassStatusLabel.Text = "Compass: running";
    }

    private void OnStopCompassClicked(object? sender, EventArgs e)
    {
        if (!Compass.Default.IsMonitoring)
        {
            return;
        }

        Compass.Default.Stop();
        Compass.Default.ReadingChanged -= OnCompassReadingChanged;
        CompassStatusLabel.Text = "Compass: stopped";
    }

    private void OnCompassReadingChanged(object? sender, CompassChangedEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            CompassStatusLabel.Text = $"Compass heading: {e.Reading.HeadingMagneticNorth:F0}°";
        });
    }

    private async void OnReadDiningTipClicked(object? sender, EventArgs e)
    {
        const string tip = "Find nearby restaurants and choose one with balanced meals and fresh ingredients.";
        await TextToSpeech.SpeakAsync(tip);
        await DisplayAlertAsync("Dining Tip", tip, "OK");
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        if (Accelerometer.Default.IsMonitoring)
        {
            Accelerometer.Default.Stop();
            Accelerometer.Default.ReadingChanged -= OnAccelerometerReadingChanged;
        }

        if (Compass.Default.IsMonitoring)
        {
            Compass.Default.Stop();
            Compass.Default.ReadingChanged -= OnCompassReadingChanged;
        }
    }
}
