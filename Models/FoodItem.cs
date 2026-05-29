namespace maui.Models;

public class FoodItem
{
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Calories { get; set; }
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fat { get; set; }
    public string AllergyNote { get; set; } = string.Empty;
    public string Tags { get; set; } = string.Empty;
    public string CaloriesLabel => $"{Calories} 千卡";
    public string MacroSummary => $"蛋白质 {Protein}克，碳水 {Carbs}克，脂肪 {Fat}克";
    public string AccessibleSummary => $"{Name}。{Category}。{Calories} 千卡。{MacroSummary}。{AllergyNote}";
}
