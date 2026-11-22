using AddisEats.Api.Data;
using AddisEats.Api.Models;

namespace AddisEats.Api.Services.RestaurantServices;

public class RestaurantService : IRestaurantService
{
    public IReadOnlyList<Restaurant> Search(string? area, int page, int limit)
    {
        var query = RestaurantData.Items
            .Where(r => r.IsActive);

        if (!string.IsNullOrWhiteSpace(area))
        {
            query = query.Where(r =>
                r.Area.Equals(area, StringComparison.OrdinalIgnoreCase));
        }
        return query
            .OrderBy(r => r.Name)
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToList();
    }

    public Restaurant? GetById(int id)
    {
        return RestaurantData.Items
            .FirstOrDefault(r => r.Id == id && r.IsActive);
    }

    public int CountAll(string? area)
    {
        var query = RestaurantData.Items
            .Where(r => r.IsActive);

        if (!string.IsNullOrWhiteSpace(area))
        {
            query = query.Where(r =>
                r.Area.Equals(area, StringComparison.OrdinalIgnoreCase));
        }
        return query.Count();
    }
}