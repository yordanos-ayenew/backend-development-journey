namespace AddisEats.Exercises;

public static class Describer
{
    public static void Describe(int value)
    {
        Console.WriteLine($"Integer overload: {value}");
    }

    public static void Describe(string value)
    {
        Console.WriteLine($"String overload: {value}");
    }

    public static void Describe(decimal value)
    {
        Console.WriteLine($"Decimal overload: {value}");
    }
}