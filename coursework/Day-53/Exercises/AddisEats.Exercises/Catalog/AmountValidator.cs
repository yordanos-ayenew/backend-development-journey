namespace AddisEats.Catalog;

public static class AmountValidator
{
    public static void ValidateAmount(decimal amount)
    {
        if (amount <= 0m)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }
        Console.WriteLine($"Valid amount: {amount:N2} ETB");
    }
}