using AddisEats.Api.Dtos;
using AddisEats.Api.Models;
using AddisEats.Api.Services.OrderServices;
using Microsoft.AspNetCore.Mvc;

namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{id:int}")]
    public ActionResult<OrderDto> GetOne(int id)
    {
        var order = _orderService.GetById(id);
        if (order is null)
            return NotFound();

        return order.ToDto();
    }

    [HttpPost]
    public ActionResult<OrderDto> Create([FromBody] CreateOrderRequest request)
    {
        var order = _orderService.Create(request);

        return CreatedAtAction(
            nameof(GetOne),
            new { id = order.Id },
            order.ToDto()
        );
    }

    [HttpPatch("{id:int}/status")]
    public ActionResult<OrderDto> UpdateStatus(
        int id,
        [FromBody] UpdateOrderStatusRequest request)
    {
        var order = _orderService.UpdateStatus(id, request.Status);

        if (order is null)
            return NotFound();

        return order.ToDto();
    }
}