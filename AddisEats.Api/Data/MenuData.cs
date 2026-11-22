using AddisEats.Api.Models;

namespace AddisEats.Api.Data;

public static class MenuData
{
    private static readonly (string Name, string Category, decimal Price)[] MenuItems =
    [
        ("Kitfo", "Traditional", 450m),
        ("Doro Wot", "Traditional", 380m),
        ("Tibs", "Traditional", 320m),
        ("Shiro", "Vegetarian", 180m),
        ("Firfir", "Traditional", 220m),
        ("Vegetable Combo", "Vegetarian", 250m)
    ];

    public static List<MenuItem> Items { get; } =
        RestaurantData.Items
            .SelectMany(restaurant =>
                MenuItems.Select((item, index) =>
                    new MenuItem
                    {
                        Id = restaurant.Id * 10 + index + 1,
                        RestaurantId = restaurant.Id,
                        Name = item.Name,
                        Category = item.Category,
                        PriceETB = item.Price
                    }))
            .ToList();
}