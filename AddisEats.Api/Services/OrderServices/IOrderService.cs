using AddisEats.Api.Models;
using AddisEats.Api.Dtos;
using AddisEats.Api.Common;

namespace AddisEats.Api.Services.OrderServices;

public interface IOrderService
{
    Result<Order> GetById(int id);
    Result<Order> Place(CreateOrderRequest request);
    Result<Order> UpdateStatus(int id, OrderStatus status);
}