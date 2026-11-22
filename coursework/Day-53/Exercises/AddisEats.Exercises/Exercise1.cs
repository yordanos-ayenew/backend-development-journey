namespace AddisEats.Exercises;

public static class DeliveryFeeCalculator
{
    public static decimal DeliveryFee(string area, bool isVip = false)
    {
        if (isVip)
        {
            return 0m;
        }

        return area switch
        {
            "Bole" => 50m,
            "Piassa" => 65m,
            "Kazanchis" => 60m,
            _ => 80m
        };
    }
}