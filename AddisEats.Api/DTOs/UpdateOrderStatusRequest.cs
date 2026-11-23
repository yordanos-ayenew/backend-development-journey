using AddisEats.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace AddisEats.Api.Dtos;

public record UpdateOrderStatusRequest(
    [property: EnumDataType(typeof(OrderStatus),
        ErrorMessage = "Invalid order status.")]
    OrderStatus Status);