using AddisEats.Api.Models;

namespace AddisEats.Api.Services.MenuServices;

public interface IMenuService
{
    List<MenuItem> GetAll(string? category, int pageSize);
    MenuItem? GetById(int id);
    MenuItem Add(CreateMenuItemRequest request);
    List<MenuItem> GetForRestaurant(int restaurantId, string? category);
}