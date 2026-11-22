namespace AddisEats.Catalog;

public class FiftyBirrDiscount : IDiscountPolicy
{
    public decimal Apply(decimal amount)
    {
        return Math.Max(0m, amount - 50m);
    }
}