using AddisEats.Api.Models;
using AddisEats.Api.Data;

namespace AddisEats.Api.Services.MenuServices;

public class MenuService : IMenuService
{
    public List<MenuItem> GetAll(string? category, int pageSize)
    {
        var query = MenuData.Items.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(m =>
                m.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }
        return query.Take(pageSize).ToList();
    }

    public MenuItem? GetById(int id)
    {
        return MenuData.Items.FirstOrDefault(m => m.Id == id);
    }

    public MenuItem Add(CreateMenuItemRequest request)
    {
        var item = new MenuItem
        {
            Id = MenuData.Items.Count == 0 ? 1 : MenuData.Items.Max(m => m.Id) + 1,
            RestaurantId = 1,
            Name = request.Name,
            Category = request.Category,
            PriceETB = request.PriceETB
        };

        MenuData.Items.Add(item);

        return item;
    }

    public List<MenuItem> GetForRestaurant(int restaurantId, string? category)
    {
        var query = MenuData.Items
            .Where(m => m.RestaurantId == restaurantId);

        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(m =>
                m.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }
        return query.ToList();
    }
}