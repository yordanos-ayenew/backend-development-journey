using AddisEats.Api.Dtos;
using AddisEats.Api.Services.MenuServices;
using AddisEats.Api.Services.RestaurantServices;
using Microsoft.AspNetCore.Mvc;

namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1/restaurants")]
public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;
    private readonly IMenuService _menuService;

    public RestaurantController(
        IRestaurantService restaurantService,
        IMenuService menuService)
    {
        _restaurantService = restaurantService;
        _menuService = menuService;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] string? area,
        [FromQuery] int page = 1,
        [FromQuery] int limit = 20)
    {
        if (page < 1 || limit < 1)
            return BadRequest("Page and limit must be greater than zero.");

        var restaurants = _restaurantService.Search(area, page, limit);

        var data = restaurants
            .Select(r => r.ToDto())
            .ToList();

        return Ok(new
        {
            data,
            page,
            pageSize = limit
        });
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var restaurant = _restaurantService.GetById(id);

        if (restaurant is null)
            return NotFound();

        return Ok(restaurant.ToDto());
    }

    [HttpGet("{id}/menu")]
    public IActionResult GetMenu(
        int id,
        [FromQuery] string? category)
    {
        var restaurant = _restaurantService.GetById(id);

        if (restaurant is null)
            return NotFound();

        var menu = _menuService.GetForRestaurant(id, category);

        return Ok(menu);
    }
}