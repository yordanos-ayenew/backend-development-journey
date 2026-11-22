using AddisEats.OrderBook.Models;
using AddisEats.OrderBook.Services;

List<MenuItem> menu =
[
    new(1, "Burger", "Fast Food", 250m),
    new(2, "Pizza", "Fast Food", 450m),
    new(3, "Shiro", "Traditional", 120m),
    new(4, "Kitfo", "Traditional", 350m),
    new(5, "Juice", "Drinks", 80m)
];

OrderBook orderBook = new();

string[] customers =
[
    "Hana", "Dawit", "Meron", "Abel", "Sara",
    "Miki", "Liya", "Daniel", "Ruth", "Samuel",
    "Marta", "Yonas"
];

string[] areas =
[
    "Bole", "Piassa", "Kazanchis"
];

for (int i = 0; i < 12; i++)
{
    var lines = new List<OrderLine>
    {
        new(menu[i % menu.Count], i % 3 + 1),
        new(menu[(i + 2) % menu.Count], 2)
    };

    Order order = new(
        i + 1,
        customers[i],
        areas[i % areas.Length],
        lines
    );

    orderBook.AddOrder(order);

    Thread.Sleep(5);
}

Console.WriteLine("=== BOLE ORDERS ===");

var boleOrders = orderBook.GetOrdersByArea("Bole");

foreach (var order in boleOrders)
{
    Console.WriteLine(
        $"{order.CustomerName} | {order.Total:N2} ETB"
    );
}

Console.WriteLine("\n=== TOTAL REVENUE ===");
Console.WriteLine($"{orderBook.GetTotalRevenue():N2} ETB");

Console.WriteLine("\n=== BUSIEST CATEGORY ===");
Console.WriteLine(orderBook.GetBusiestCategory());

// Pagination
Console.WriteLine("\n=== PAGE 1 ===");

foreach (var order in orderBook.GetPage(1))
{
    Console.WriteLine($"{order.Id} | {order.CustomerName}");
}

Console.WriteLine("\n=== PAGE 2 ===");

foreach (var order in orderBook.GetPage(2))
{
    Console.WriteLine($"{order.Id} | {order.CustomerName}");
}