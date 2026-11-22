using AddisEats.Api.Data;
using AddisEats.Api.Models;
using AddisEats.Api.Dtos;

namespace AddisEats.Api.Services.RestaurantServices;

public class RestaurantService : IRestaurantService
{
    public IReadOnlyList<Restaurant> Search(RestaurantQuery query)
    {
        var restaurants = ApplyFilters(query);

        return restaurants
            .OrderBy(r => r.Name)
            .Skip((query.Page - 1) * query.Limit)
            .Take(query.Limit)
            .ToList();
    }

    public Restaurant? GetById(int id)
    {
        return RestaurantData.Items
            .FirstOrDefault(r => r.Id == id && r.IsActive);
    }

    public int CountAll(RestaurantQuery query)
    {
        return ApplyFilters(query).Count();
    }

    private static IEnumerable<Restaurant> ApplyFilters(RestaurantQuery query)
    {
        var restaurants = RestaurantData.Items
            .Where(r => r.IsActive);

        if (!string.IsNullOrWhiteSpace(query.Area))
        {
            restaurants = restaurants.Where(r =>
                r.Area.Equals(query.Area, StringComparison.OrdinalIgnoreCase));
        }
        if (query.Areas.Count > 0)
        {
            restaurants = restaurants.Where(r =>
                query.Areas.Contains(r.Area, StringComparer.OrdinalIgnoreCase));
        }
        if (query.MaxFeeEtb.HasValue)
        {
            restaurants = restaurants.Where(r =>
                r.DeliveryFeeEtb <= query.MaxFeeEtb.Value);
        }

        return restaurants;
    }
}