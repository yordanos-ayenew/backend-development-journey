namespace AddisEats.Catalog;

public class TenPercentDiscount : IDiscountPolicy
{
    public decimal Apply(decimal amount)
    {
        return amount * 0.90m;
    }
}