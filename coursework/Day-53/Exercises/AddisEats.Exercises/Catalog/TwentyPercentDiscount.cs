namespace AddisEats.Catalog;

public class TwentyPercentDiscount : IDiscountPolicy
{
    public decimal Apply(decimal amount)
    {
        return amount * 0.80m;
    }
}