using AddisEats.Api.Models;
using AddisEats.Api.Options;
using AddisEats.Api.Services.MenuServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using AddisEats.Api.Dtos;

namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1/menu-items")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;
    private readonly MenuOptions _menuOptions;

    public MenuController(
        IMenuService menuService,
        IOptions<MenuOptions> options)
    {
        _menuService = menuService;
        _menuOptions = options.Value;
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] string? category)
    {
        var menu = _menuService.GetAll(
            category,
            _menuOptions.DefaultPageSize
        );

        return Ok(menu);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var item = _menuService.GetById(id);

        return item == null 
            ? NotFound(new ApiError(
                "MENU_ITEM_NOT_FOUND",
                $"Menu item with ID {id} was not found."
            ))
            : Ok(item);
    }

    [HttpPost]
    public IActionResult Create(CreateMenuItemRequest request)
    {
        if (request.PriceETB <= 0)
        {
            return BadRequest(new ApiError(
                "INVALID_PRICE",
                "Menu item price must be greater than zero."
            ));
        }

        var item = _menuService.Add(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = item.Id },
            item
        );
    }
}