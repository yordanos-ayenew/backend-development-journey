// Exercise 2

Console.WriteLine("Yordanos Ayenew");
Console.WriteLine(DateTime.Now.ToString("dd MMM yyyy"));
Console.WriteLine("CodeOps Module 4 — .NET track");

// Exercise 3

int quantity = 5;
long orderNumber = 9876543210L;
decimal orderTotal = 480.50m;
double deliveryDistance = 9.03;
bool isDelivered = true;
char size = 'L';
string deliveryArea = "Bole";
DateTime orderDate = DateTime.Now;

Console.WriteLine($"int: {quantity}");
Console.WriteLine($"long: {orderNumber}");
Console.WriteLine($"decimal: {orderTotal}");
Console.WriteLine($"double: {deliveryDistance}");
Console.WriteLine($"bool: {isDelivered}");
Console.WriteLine($"char: {size}");
Console.WriteLine($"string: {deliveryArea}");
Console.WriteLine($"DateTime: {orderDate}");

// Exercise 4

decimal subtotal = 1480.5m;
decimal deliveryFee = 60m;
decimal total = subtotal + deliveryFee;

Console.WriteLine("========== ADDIS EATS ==========");
Console.WriteLine($"{"Subtotal:",-15} {subtotal,10:N2} ETB");
Console.WriteLine($"{"Delivery Fee:",-15} {deliveryFee,10:N2} ETB");
Console.WriteLine($"{"Total:",-15} {total,10:N2} ETB");

// Exercise 5

int result1 = 7 / 2;
decimal result2 = (decimal)7 / 2;

Console.WriteLine($"Integer division: {result1}");
Console.WriteLine($"Decimal division: {result2}");

// Exercise 6

int originalNumber = 100;
int copiedNumber = originalNumber;

copiedNumber = 200;

Console.WriteLine("VALUE TYPES");
Console.WriteLine($"Original: {originalNumber}");
Console.WriteLine($"Copy: {copiedNumber}");

List<string> originalAreas = new List<string> { "Bole" };
List<string> copiedAreas = originalAreas;

copiedAreas.Add("Piassa");

Console.WriteLine("\nREFERENCE TYPES");
Console.WriteLine($"Original: {string.Join(", ", originalAreas)}");
Console.WriteLine($"Copy: {string.Join(", ", copiedAreas)}");

// Exercise 7

string? deliveryNote = null;

// 1. Explicit null check
if (deliveryNote != null)
{
    Console.WriteLine($"Length: {deliveryNote.Length}");
}
else
{
    Console.WriteLine("Explicit check: No delivery note.");
}

// 2. Null-coalescing operator
int length = (deliveryNote ?? "").Length;
Console.WriteLine($"Using ??: {length}");

// 3. Null-conditional operator
int? nullableLength = deliveryNote?.Length;
Console.WriteLine($"Using ?.: {nullableLength?.ToString() ?? "No value"}");

// Exercise 8

Console.WriteLine("Enter an ETB amount:");
string? input = Console.ReadLine();

if (!decimal.TryParse(input, out decimal amount))
{
    Console.WriteLine("Invalid input. Please enter a number.");
}
else if (amount <= 0)
{
    Console.WriteLine("Amount must be greater than zero.");
}
else
{
    Console.WriteLine($"Amount received: {amount:N2} ETB");
}