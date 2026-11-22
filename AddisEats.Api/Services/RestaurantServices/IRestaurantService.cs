using AddisEats.Api.Models;
using AddisEats.Api.Dtos;

namespace AddisEats.Api.Services.RestaurantServices;

public interface IRestaurantService
{
    IReadOnlyList<Restaurant> Search(RestaurantQuery query);
    Restaurant? GetById(int id);
    int CountAll(RestaurantQuery query);
}