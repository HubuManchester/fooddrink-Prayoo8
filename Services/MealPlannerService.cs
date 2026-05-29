using maui.Models;

namespace maui.Services
{
    public class MealPlannerService
    {
        public bool TryCreateMealPlanItem(
            string mealType,
            string mealName,
            string caloriesInput,
            DateTime plannedDate,
            string? notes,
            out MealPlanItem? item,
            out string errorMessage)
        {
            item = null;
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(mealName))
            {
                errorMessage = "Meal name cannot be empty.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(caloriesInput) || !int.TryParse(caloriesInput, out var calories))
            {
                errorMessage = "Calories must be a valid number.";
                return false;
            }

            if (calories <= 0 || calories > 3000)
            {
                errorMessage = "Calories must be between 1 and 3000.";
                return false;
            }

            item = new MealPlanItem
            {
                MealType = string.IsNullOrWhiteSpace(mealType) ? "Meal" : mealType,
                MealName = mealName.Trim(),
                Calories = calories,
                PlannedDate = plannedDate,
                Notes = notes?.Trim() ?? string.Empty
            };

            return true;
        }

        public int CalculateTotalCalories(IEnumerable<MealPlanItem> meals)
        {
            return meals.Sum(x => x.Calories);
        }
    }
}
