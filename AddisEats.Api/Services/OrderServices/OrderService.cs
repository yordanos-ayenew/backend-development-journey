using AddisEats.Api.Data;
using AddisEats.Api.Dtos;
using AddisEats.Api.Models;
using AddisEats.Api.Services.MenuServices;
using AddisEats.Api.Services.RestaurantServices;
using AddisEats.Api.Common;

namespace AddisEats.Api.Services.OrderServices;

public class OrderService : IOrderService
{
    private readonly IRestaurantService _restaurantService;
    private readonly IMenuService _menuService;

    public OrderService(
        IRestaurantService restaurantService,
        IMenuService menuService)
    {
        _restaurantService = restaurantService;
        _menuService = menuService;
    }

    public Result<Order> GetById(int id)
    {
        var order = OrderData.Items.FirstOrDefault(o => o.Id == id);
        if (order is null)
        {
            return Result<Order>.Fail(
                "ORDER_NOT_FOUND",
                $"Order with ID {id} was not found.",
                404);
        }
        return Result<Order>.Ok(order);
    }

    public Result<Order> Place(CreateOrderRequest request)
    {
        var restaurant = _restaurantService.GetById(request.RestaurantId);

        if (restaurant is null)
        {
            return Result<Order>.Fail(
                "RESTAURANT_NOT_FOUND",
                "The selected restaurant does not exist.",
                404);
        }

        if (!restaurant.IsActive)
        {
            return Result<Order>.Fail(
                "RESTAURANT_CLOSED",
                "This restaurant is currently closed.",
                409);
        }

        var existingOpenOrders = OrderData.Items.Count(o =>
            o.Phone == request.Phone &&
            o.Status != OrderStatus.Delivered &&
            o.Status != OrderStatus.Cancelled);

        if (existingOpenOrders >= 5)
        {
            return Result<Order>.Fail(
                "MAX_OPEN_ORDERS",
                "You cannot have more than five open orders.",
                409);
        }

        var orderLines = new List<OrderLine>();

        foreach (var itemRequest in request.Items)
        {
            var menuItem = _menuService.GetById(itemRequest.MenuItemId);
            if (menuItem is null ||
                menuItem.RestaurantId != restaurant.Id)
            {
                return Result<Order>.Fail(
                    "MENU_ITEM_MISMATCH",
                    $"Menu item {itemRequest.MenuItemId} does not belong to this restaurant.",
                    422);
            }

            orderLines.Add(new OrderLine
            {
                MenuItemId = menuItem.Id,
                MenuItemName = menuItem.Name,
                Qty = itemRequest.Qty,
                UnitPriceEtb = menuItem.PriceETB,
                LineTotalEtb = menuItem.PriceETB * itemRequest.Qty
            });
        }

        var subtotal = orderLines.Sum(item => item.LineTotalEtb);
        var deliveryFee = restaurant.DeliveryFeeEtb;

        var order = new Order
        {
            Id = OrderData.Items.Count == 0
                ? 1
                : OrderData.Items.Max(o => o.Id) + 1,

            RestaurantId = restaurant.Id,
            Area = request.Area,
            Phone = request.Phone,
            Items = orderLines,
            SubtotalEtb = subtotal,
            DeliveryFeeEtb = deliveryFee,
            TotalEtb = subtotal + deliveryFee,
            Status = OrderStatus.Placed
        };

        OrderData.Items.Add(order);
        return Result<Order>.Ok(order);
    }

    public Result<Order> UpdateStatus(int id, OrderStatus status)
    {
        var order =  OrderData.Items.FirstOrDefault(o => o.Id == id);
        if (order is null)
        {
            return Result<Order>.Fail(
                "ORDER_NOT_FOUND",
                $"Order with ID {id} was not found.",
                404);
        }

        if (order.Status == OrderStatus.Delivered ||
            order.Status == OrderStatus.Cancelled)
        {
            return Result<Order>.Fail(
                "ORDER_STATUS_CONFLICT",
                "This order can no longer be updated.",
                409);
        }
        order.Status = status;
        return Result<Order>.Ok(order);
    }
}