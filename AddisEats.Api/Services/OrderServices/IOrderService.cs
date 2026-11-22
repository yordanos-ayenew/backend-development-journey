using AddisEats.Api.Models;
using AddisEats.Api.Dtos;

namespace AddisEats.Api.Services.OrderServices;

public interface IOrderService
{
    Order? GetById(int id);
    Order Create(CreateOrderRequest request);
    Order? UpdateStatus(int id, OrderStatus status);
}