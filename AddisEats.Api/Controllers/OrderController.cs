using AddisEats.Api.Dtos;
using AddisEats.Api.Models;
using AddisEats.Api.Services.OrderServices;
using Microsoft.AspNetCore.Mvc;
using AddisEats.Api.Common;
using AddisEats.Api.Filters;

namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1/orders")]
[ServiceFilter(typeof(AuditActionFilter))]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOne(int id)
    {
        var result = _orderService.GetById(id);
        if (!result.IsSuccess)
            return result.ToActionResult(this);

        return Ok(result.Value!.ToDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateOrderRequest request)
    {
        var result = _orderService.Place(request);
        if (!result.IsSuccess)
            return result.ToActionResult(this);

        var order = result.Value!;

        return CreatedAtAction(
            nameof(GetOne),
            new { id = order.Id },
            order.ToDto()
        );
    }

    [HttpPatch("{id:int}/status")]
    public IActionResult UpdateStatus(
        int id,
        UpdateOrderStatusRequest request)
    {
        var result = _orderService.UpdateStatus(id, request.Status);
        if (!result.IsSuccess)
            return result.ToActionResult(this);

        return Ok(result.Value!.ToDto());
    }
}