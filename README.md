# 食光营养助手 (Food & Drink Explorer)

一个基于 .NET MAUI 的跨平台移动应用，帮助用户记录食品和饮品的营养信息，养成健康饮食习惯。

## 功能特性

### 食品管理
- 浏览食品列表，支持搜索（名称、分类、标签）
- 查看食品营养详情（热量、蛋白质、碳水、脂肪、过敏提示）
- 添加新的食品记录，含完整表单验证

### 膳食计划
- 按餐类型（早餐/午餐/晚餐/零食）规划膳食
- 记录热量并自动汇总
- 日期和备注管理

### 设备硬件集成
- **相机**：拍摄食品照片
- **GPS 定位**：获取当前位置坐标
- **加速度计**：实时显示运动数据
- **指南针**：磁北方向指示
- **文字转语音**：朗读营养摘要，支持中文语音优先
- **震动反馈**：操作反馈震动
- **触觉反馈**：精细触觉反馈

### 无障碍功能
- 深色/浅色/跟随系统主题切换
- 大字体模式
- 语义属性标注，支持屏幕阅读器
- 动态字体大小调节

## 技术栈
- .NET 10.0 MAUI
- XAML + Code-Behind
- Models / Services 分层架构

## 支持平台
- Android
- iOS
- macOS (MacCatalyst)
- Windows

## 项目结构
```
├── App.xaml / App.xaml.cs          # 应用入口
├── AppShell.xaml / .cs             # Shell 导航
├── MainPage.xaml / .cs             # 食品列表页
├── FoodDetailPage.xaml / .cs       # 食品详情页
├── AddItemPage.xaml / .cs          # 添加食品页
├── MealPlannerPage.xaml / .cs      # 膳食计划页
├── DeviceToolsPage.xaml / .cs      # 设备工具页
├── SettingsPage.xaml / .cs         # 设置页
├── Models/
│   ├── FoodItem.cs                 # 食品数据模型
│   └── MealPlanItem.cs            # 膳食计划模型
├── Services/
│   ├── FoodCatalogService.cs       # 食品数据服务
│   ├── MealPlannerService.cs       # 膳食计划服务
│   ├── SpeechService.cs            # 语音朗读服务
│   └── AccessibilityService.cs     # 无障碍服务
├── Platforms/                      # 各平台入口
└── Resources/                      # 样式、图标、字体
```
