# Food & Drink Explorer

A cross-platform mobile application built with .NET MAUI that helps users track food and drink nutrition information and build healthy eating habits.

## Features

### Food Management
- Browse food list with search support (name, category, tags)
- View food nutrition details (calories, protein, carbs, fat, allergy notes)
- Add new food records with complete form validation

### Meal Planner
- Plan meals by type (breakfast / lunch / dinner / snack)
- Track calories with automatic total summary
- Date and notes management

### Device Hardware Integration
- **Camera**: Take food photos
- **GPS Location**: Get current position coordinates
- **Accelerometer**: Display real-time motion data
- **Compass**: Magnetic north heading indicator
- **Text-to-Speech**: Read nutrition summaries aloud, prefers Chinese voice
- **Vibration**: Haptic feedback on user actions
- **Haptic Feedback**: Fine-grained tactile feedback

### Accessibility
- Dark / Light / Follow System theme switching
- Large font mode
- Semantic property annotations for screen reader support
- Dynamic font size adjustment

## Tech Stack
- .NET 10.0 MAUI
- XAML + Code-Behind
- Models / Services layered architecture

## Supported Platforms
- Android
- iOS
- macOS (MacCatalyst)
- Windows

## Project Structure
```
├── App.xaml / App.xaml.cs          # App entry point
├── AppShell.xaml / .cs             # Shell navigation
├── MainPage.xaml / .cs             # Food list page
├── FoodDetailPage.xaml / .cs       # Food detail page
├── AddItemPage.xaml / .cs          # Add food page
├── MealPlannerPage.xaml / .cs      # Meal planner page
├── DeviceToolsPage.xaml / .cs      # Device tools page
├── SettingsPage.xaml / .cs         # Settings page
├── Models/
│   ├── FoodItem.cs                 # Food data model
│   └── MealPlanItem.cs            # Meal plan model
├── Services/
│   ├── FoodCatalogService.cs       # Food data service
│   ├── MealPlannerService.cs       # Meal planner service
│   ├── SpeechService.cs            # Text-to-speech service
│   └── AccessibilityService.cs     # Accessibility service
├── Platforms/                      # Platform-specific entry points
└── Resources/                      # Styles, icons, fonts
```

## Build and Run

Windows:
```powershell
dotnet build .\maui.csproj -f net10.0-windows10.0.19041.0
```

Android:
```powershell
dotnet build .\maui.csproj -f net10.0-android
```
