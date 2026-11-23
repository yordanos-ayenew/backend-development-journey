using AddisEats.Api.Validation;

namespace AddisEats.Api.Models;

public record CreateMenuItemRequest(
    string Name,
    string Category,
    [property: EtbAmount]
    decimal PriceETB
);