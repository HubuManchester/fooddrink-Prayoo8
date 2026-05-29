using maui.Models;

namespace maui.Services;

public static class FoodCatalogService
{
    private static readonly List<FoodItem> _items = new()
    {
        new FoodItem { Name = "番茄意面", Category = "主食", Description = "经典意大利面配新鲜番茄酱", Calories = 450, Protein = 15, Carbs = 65, Fat = 12, Tags = "意面,番茄,午餐" },
        new FoodItem { Name = "三文鱼刺身", Category = "日料", Description = "新鲜三文鱼切片，搭配芥末和酱油", Calories = 280, Protein = 25, Carbs = 2, Fat = 18, AllergyNote = "含鱼类", Tags = "日料,刺身,晚餐" },
        new FoodItem { Name = "牛油果沙拉", Category = "沙拉", Description = "混合蔬菜配牛油果和柠檬汁", Calories = 320, Protein = 8, Carbs = 20, Fat = 24, Tags = "沙拉,健康,午餐" },
        new FoodItem { Name = "红豆奶茶", Category = "饮品", Description = "香浓奶茶配红豆", Calories = 280, Protein = 6, Carbs = 45, Fat = 8, AllergyNote = "含乳制品", Tags = "奶茶,饮品,下午茶" },
        new FoodItem { Name = "鸡胸肉便当", Category = "主食", Description = "低脂鸡胸肉配糙米饭和蔬菜", Calories = 380, Protein = 35, Carbs = 40, Fat = 8, Tags = "便当,健康,午餐" },
        new FoodItem { Name = "希腊酸奶", Category = "甜品", Description = "浓稠酸奶配蜂蜜和坚果", Calories = 200, Protein = 12, Carbs = 22, Fat = 8, AllergyNote = "含乳制品、坚果", Tags = "酸奶,早餐,甜品" },
        new FoodItem { Name = "墨西哥卷饼", Category = "主食", Description = "玉米饼卷牛肉、蔬菜和莎莎酱", Calories = 520, Protein = 28, Carbs = 48, Fat = 22, Tags = "墨西哥,午餐,卷饼" },
        new FoodItem { Name = "抹茶拿铁", Category = "饮品", Description = "日式抹茶配牛奶", Calories = 180, Protein = 5, Carbs = 25, Fat = 6, AllergyNote = "含乳制品", Tags = "抹茶,饮品,下午茶" },
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

    public static void Add(FoodItem item)
    {
        _items.Add(item);
    }
}
