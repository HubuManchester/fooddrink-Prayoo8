namespace maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(FoodDetailPage), typeof(FoodDetailPage));
        Routing.RegisterRoute(nameof(AddItemPage), typeof(AddItemPage));
    }
}
