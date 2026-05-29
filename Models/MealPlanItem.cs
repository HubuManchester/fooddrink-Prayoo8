namespace maui.Models;

public class MealPlanItem
{
    public string MealType { get; set; } = string.Empty;

    public string MealName { get; set; } = string.Empty;

    public int Calories { get; set; }

    public DateTime PlannedDate { get; set; }

    public string Notes { get; set; } = string.Empty;
}
