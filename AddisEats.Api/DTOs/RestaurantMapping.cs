using AddisEats.Api.Models;

namespace AddisEats.Api.Dtos;

public static class RestaurantMapping
{
    public static RestaurantDto ToDto(this Restaurant restaurant)
    {
        return new RestaurantDto(
            restaurant.Id,
            restaurant.Name,
            restaurant.Area,
            restaurant.DeliveryFeeEtb
        );
    }
}