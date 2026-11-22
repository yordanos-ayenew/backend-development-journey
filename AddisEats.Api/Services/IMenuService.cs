using AddisEats.Api.Models;

namespace AddisEats.Api.Services;

public interface IMenuService
{
    List<MenuItem> GetAll(string? category, int pageSize);
    MenuItem? GetById(int id);
    MenuItem Add(CreateMenuItemRequest request);
}