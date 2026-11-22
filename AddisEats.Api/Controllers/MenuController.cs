using AddisEats.Api.Models;
using AddisEats.Api.Options;
using AddisEats.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1/menu")]
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

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var item = _menuService.GetById(id);

        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public IActionResult Create(CreateMenuItemRequest request)
    {
        if (request.PriceETB <= 0)
        {
            return BadRequest("Price must be greater than zero.");
        }

        var item = _menuService.Add(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = item.Id },
            item
        );
    }
}