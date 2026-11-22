using AddisEats.Api.Dtos;
using AddisEats.Api.Services.MenuServices;
using AddisEats.Api.Services.RestaurantServices;
using Microsoft.AspNetCore.Mvc;
using AddisEats.Api.Models;

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
    public ActionResult<PagedResult<RestaurantDto>> GetAll(
    [FromQuery] RestaurantQuery query)
    {
        if (query.Page < 1 || query.Limit < 1)
            return BadRequest("Page and limit must be greater than zero.");

        var restaurants = _restaurantService.Search(query);

        var data = restaurants
            .Select(r => r.ToDto())
            .ToList();

        var total = _restaurantService.CountAll(query);

        return Ok(new
        {
            data,
            query.Page,
            query.Limit,
            total
        });
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var restaurant = _restaurantService.GetById(id);

        if (restaurant is null)
            return NotFound();

        return Ok(restaurant.ToDto());
    }

    [HttpGet("{id:int}/menu")]
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