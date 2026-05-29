using maui.Models;

namespace maui.Services;

public static class FoodCatalogService
{
    private static readonly List<FoodItem> _items = new()
    {
        new FoodItem { Name = "Tomato Pasta", Category = "Main Course", Description = "Classic spaghetti with fresh tomato sauce", Calories = 450, Protein = 15, Carbs = 65, Fat = 12, Tags = "pasta,tomato,lunch" },
        new FoodItem { Name = "Salmon Sashimi", Category = "Japanese", Description = "Fresh salmon slices with wasabi and soy sauce", Calories = 280, Protein = 25, Carbs = 2, Fat = 18, AllergyNote = "Contains fish", Tags = "japanese,sashimi,dinner" },
        new FoodItem { Name = "Avocado Salad", Category = "Salad", Description = "Mixed greens with avocado and lemon dressing", Calories = 320, Protein = 8, Carbs = 20, Fat = 24, Tags = "salad,healthy,lunch" },
        new FoodItem { Name = "Red Bean Milk Tea", Category = "Beverage", Description = "Rich milk tea with red beans", Calories = 280, Protein = 6, Carbs = 45, Fat = 8, AllergyNote = "Contains dairy", Tags = "milk tea,beverage,afternoon tea" },
        new FoodItem { Name = "Chicken Breast Bento", Category = "Main Course", Description = "Low-fat chicken breast with brown rice and vegetables", Calories = 380, Protein = 35, Carbs = 40, Fat = 8, Tags = "bento,healthy,lunch" },
        new FoodItem { Name = "Greek Yogurt", Category = "Dessert", Description = "Thick yogurt with honey and nuts", Calories = 200, Protein = 12, Carbs = 22, Fat = 8, AllergyNote = "Contains dairy and nuts", Tags = "yogurt,breakfast,dessert" },
        new FoodItem { Name = "Burrito", Category = "Main Course", Description = "Tortilla wrap with beef, vegetables and salsa", Calories = 520, Protein = 28, Carbs = 48, Fat = 22, Tags = "mexican,lunch,burrito" },
        new FoodItem { Name = "Matcha Latte", Category = "Beverage", Description = "Japanese matcha with milk", Calories = 180, Protein = 5, Carbs = 25, Fat = 6, AllergyNote = "Contains dairy", Tags = "matcha,beverage,afternoon tea" },
    };

    public static List<FoodItem> GetAll() => _items.ToList();

    public static List<FoodItem> Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query)) return GetAll();
        var q = query.Trim().ToLowerInvariant();
        return _items.Where(f =>
            f.Name.Contains(q, StringComparison.OrdinalIgnoreCase) ||
            f.Category.Contains(q, StringComparison.OrdinalIgnoreCase) ||
            f.Description.Contains(q, StringComparison.OrdinalIgnoreCase) ||
            f.Tags.Contains(q, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }

    public static event Action? FoodAdded;

    public static void Add(FoodItem item)
    {
        _items.Add(item);
        FoodAdded?.Invoke();
    }
}
