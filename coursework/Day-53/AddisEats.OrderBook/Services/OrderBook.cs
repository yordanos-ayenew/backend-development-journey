using AddisEats.OrderBook.Models;

namespace AddisEats.OrderBook.Services;

public class OrderBook
{
    private readonly List<Order> _orders = [];

    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }

    // 1. Get orders by area, highest total first
    public List<Order> GetOrdersByArea(string area)
    {
        return _orders
            .Where(o => o.Area == area)
            .OrderByDescending(o => o.Total)
            .ToList();
    }

    // 2. Calculate total revenue
    public decimal GetTotalRevenue()
    {
        return _orders.Sum(o => o.Total);
    }

    // 3. Find the busiest category
    public string GetBusiestCategory()
    {
        return _orders
            .SelectMany(o => o.Lines)
            .GroupBy(line => line.Item.Category)
            .OrderByDescending(group => group.Sum(line => line.Quantity))
            .Select(group => group.Key)
            .FirstOrDefault() ?? "No orders yet";
    }

    // 4. Get five orders per page, newest first
    public List<Order> GetPage(int pageNumber)
    {
        if (pageNumber < 1)
        {
            throw new ArgumentException("Page number must be at least 1.");
        }

        return _orders
            .OrderByDescending(o => o.PlacedOn)
            .Skip((pageNumber - 1) * 5)
            .Take(5)
            .ToList();
    }
}