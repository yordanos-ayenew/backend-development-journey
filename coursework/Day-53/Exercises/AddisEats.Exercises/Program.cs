using AddisEats.Exercises;
using AddisEats.Catalog;

// EXERCISE 1 — METHODS AND OPTIONAL PARAMETERS

Console.WriteLine("========== EXERCISE 1 ==========");

decimal fee1 = DeliveryFeeCalculator.DeliveryFee("Bole", true);
decimal fee2 = DeliveryFeeCalculator.DeliveryFee("Piassa", isVip: true);
decimal fee3 = DeliveryFeeCalculator.DeliveryFee("Kazanchis");

Console.WriteLine($"VIP in Bole: {fee1:N2} ETB");
Console.WriteLine($"VIP in Piassa: {fee2:N2} ETB");
Console.WriteLine($"Regular customer in Kazanchis: {fee3:N2} ETB");


// EXERCISE 2 — METHOD OVERLOADING

Console.WriteLine("\n========== EXERCISE 2 ==========");

Describer.Describe(42);
Describer.Describe("Bole");
Describer.Describe(480.50m);


// EXERCISE 3 — CLASSES AND PROPERTIES

Console.WriteLine("\n========== EXERCISE 3 ==========");

Restaurant restaurant = new Restaurant
{
    Id = 1,
    Name = "Addis Eats",
    Area = "Bole"
};

Console.WriteLine($"ID: {restaurant.Id}");
Console.WriteLine($"Restaurant: {restaurant.DisplayName}");

restaurant.Name = "Addis Kitchen";

Console.WriteLine($"Updated: {restaurant.DisplayName}");


// EXERCISE 4 — RECORDS VS CLASSES

Console.WriteLine("\n========== EXERCISE 4 ==========");

Customer customer1 = new("Hana", "0911223344");
Customer customer2 = new("Hana", "0911223344");

Console.WriteLine($"Records equal: {customer1 == customer2}");

CustomerClass person1 = new("Hana", "0911223344");
CustomerClass person2 = new("Hana", "0911223344");

Console.WriteLine($"Classes equal: {person1 == person2}");


// EXERCISE 5 — COLLECTIONS AND LINQ

Console.WriteLine("\n========== EXERCISE 5 ==========");

var orders = Enumerable.Range(1, 30)
    .Select(i => new Order(
        i,
        $"Customer {i}",
        i % 3 == 0 ? "Bole" : i % 3 == 1 ? "Kazanchis" : "Piassa",
        i * 100m,
        DateTime.Today.AddDays(-i)
    ))
    .ToList();

// 1. Orders in Bole over 500 ETB
var boleOrders = orders
    .Where(o => o.Area == "Bole" && o.Subtotal > 500m)
    .ToList();

Console.WriteLine($"Bole orders over 500 ETB: {boleOrders.Count}");

// 2. Customer names alphabetically
var customerNames = orders
    .Select(o => o.CustomerName)
    .OrderBy(name => name)
    .ToList();

Console.WriteLine("\nCustomer names:");

customerNames.ForEach(Console.WriteLine);

// 3. Total revenue from Kazanchis
decimal kazanchisRevenue = orders
    .Where(o => o.Area == "Kazanchis")
    .Sum(o => o.Subtotal);

Console.WriteLine($"\nKazanchis revenue: {kazanchisRevenue:N2} ETB");

// 4. Page 3, 10 orders per page, newest first
var pageThree = orders
    .OrderByDescending(o => o.PlacedOn)
    .Skip((3 - 1) * 10)
    .Take(10)
    .ToList();

Console.WriteLine("\nPage 3:");

foreach (var order in pageThree)
{
    Console.WriteLine(
        $"{order.Id} | {order.CustomerName} | {order.Subtotal:N2} ETB"
    );
}


// EXERCISE 6 — INTERFACES AND POLYMORPHISM

Console.WriteLine("\n========== EXERCISE 6 ==========");

IDiscountPolicy tenPercent = new TenPercentDiscount();
IDiscountPolicy fiftyBirr = new FiftyBirrDiscount();
IDiscountPolicy twentyPercent = new TwentyPercentDiscount();

Console.WriteLine($"10% discount: {ApplyDiscount(tenPercent, 1000m):N2} ETB");
Console.WriteLine($"50 ETB discount: {ApplyDiscount(fiftyBirr, 1000m):N2} ETB");
Console.WriteLine($"20% discount: {ApplyDiscount(twentyPercent, 1000m):N2} ETB");

decimal ApplyDiscount(IDiscountPolicy policy, decimal amount)
{
    return policy.Apply(amount);
}


// EXERCISE 7 — EXCEPTION HANDLING

Console.WriteLine("\n========== EXERCISE 7 ==========");

TestAmount(500m);
TestAmount(0m);

void TestAmount(decimal amount)
{
    try
    {
        AmountValidator.ValidateAmount(amount);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    finally
    {
        Console.WriteLine("Validation attempt completed.\n");
    }
}