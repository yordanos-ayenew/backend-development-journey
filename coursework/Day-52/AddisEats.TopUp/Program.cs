string[] names = new string[5];
string[] networks = new string[5];
decimal[] amounts = new decimal[5];

decimal[] percentageBonuses = new decimal[5];
decimal[] additionalBonuses = new decimal[5];
decimal[] totalBonuses = new decimal[5];
decimal[] finalCredits = new decimal[5];

decimal grandTotalAmount = 0m;
decimal grandTotalBonus = 0m;
decimal grandTotalCredit = 0m;

// Collect customer information
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"\n========== CUSTOMER {i + 1} ==========");

    Console.Write("Enter customer name: ");
    names[i] = Console.ReadLine()?.Trim() ?? "";

    while (string.IsNullOrWhiteSpace(names[i]))
    {
        Console.Write("Name cannot be empty. Enter name again: ");
        names[i] = Console.ReadLine()?.Trim() ?? "";
    }

    Console.Write("Enter network (ethiotelecom/safaricom): ");
    networks[i] = (Console.ReadLine() ?? "").Trim().ToLower();

    while (networks[i] != "ethiotelecom" &&
           networks[i] != "safaricom")
    {
        Console.Write("Invalid network. Try again: ");
        networks[i] = (Console.ReadLine() ?? "").Trim().ToLower();
    }

    Console.Write("Enter top-up amount: ");
    string? input = Console.ReadLine();

    while (!decimal.TryParse(input, out amounts[i]) ||
           amounts[i] <= 0 ||
           amounts[i] > 5000m)
    {
        Console.WriteLine("Enter a valid amount between 0 and 5000 ETB.");
        Console.Write("Enter top-up amount again: ");
        input = Console.ReadLine();
    }

    // Calculate percentage bonus using switch expression
    decimal percentage = networks[i] switch
    {
        "ethiotelecom" => 0.05m,
        "safaricom" => 0.03m,
        _ => 0m
    };

    percentageBonuses[i] = amounts[i] * percentage;

    // Calculate additional bonus
    additionalBonuses[i] = amounts[i] >= 1000m ? 20m : 0m;

    // Calculate total bonus and final credit
    totalBonuses[i] = percentageBonuses[i] + additionalBonuses[i];

    finalCredits[i] = amounts[i] + totalBonuses[i];

    // Grand totals
    grandTotalAmount += amounts[i];
    grandTotalBonus += totalBonuses[i];
    grandTotalCredit += finalCredits[i];
}

// Display final receipt
Console.WriteLine("\n");
Console.WriteLine("==========================================================================");
Console.WriteLine("                         TELEBIRR TOP-UP REPORT");
Console.WriteLine("==========================================================================");

Console.WriteLine(
    $"{"Customer",-18} {"Network",-15} {"Amount",12} {"Bonus",12} {"Final Credit",15}");

Console.WriteLine("--------------------------------------------------------------------------");

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(
        $"{names[i],-18} {networks[i],-15} {amounts[i],12:N2} {totalBonuses[i],12:N2} {finalCredits[i],15:N2}");
}

Console.WriteLine("--------------------------------------------------------------------------");

Console.WriteLine(
    $"{"GRAND TOTAL",-33} {grandTotalAmount,12:N2} {grandTotalBonus,12:N2} {grandTotalCredit,15:N2}");

Console.WriteLine("==========================================================================");
Console.WriteLine("                  Thank you for using TeleBirr!");
Console.WriteLine("==========================================================================");