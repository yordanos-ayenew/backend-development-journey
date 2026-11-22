using AddisEats.Api.Models;

namespace AddisEats.Api.Services;

public class MenuService : IMenuService
{
    private readonly List<MenuItem> _menu =
    [
        new MenuItem { Id = 1, Name = "Kitfo", Category = "Traditional", PriceETB = 350m },
        new MenuItem { Id = 2, Name = "Shiro", Category = "Traditional", PriceETB = 120m },
        new MenuItem { Id = 3, Name = "Tibs", Category = "Traditional", PriceETB = 280m },
        new MenuItem { Id = 4, Name = "Burger", Category = "Fast Food", PriceETB = 250m },
        new MenuItem { Id = 5, Name = "Pizza", Category = "Fast Food", PriceETB = 450m }
    ];

    public List<MenuItem> GetAll(string? category, int pageSize)
    {
        return _menu
            .Where(item => category == null ||
                item.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            .Take(pageSize)
            .ToList();
    }

    public MenuItem? GetById(int id)
    {
        return _menu.FirstOrDefault(item => item.Id == id);
    }

    public MenuItem Add(CreateMenuItemRequest request)
    {
        var item = new MenuItem
        {
            Id = _menu.Count == 0 ? 1 : _menu.Max(item => item.Id) + 1,
            Name = request.Name,
            Category = request.Category,
            PriceETB = request.PriceETB
        };

        _menu.Add(item);

        return item;
    }
}