namespace AddisEats.Api.Models;

public record MenuItem
{
    public int Id { get; init; }
    public int RestaurantId { get; init; }
    public string Name { get; init; } = "";
    public string Category { get; init; } = "";
    public decimal PriceETB { get; init; }
}