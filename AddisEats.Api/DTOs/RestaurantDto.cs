namespace AddisEats.Api.Dtos;

public record RestaurantDto(
    int Id,
    string Name,
    string Area,
    decimal DeliveryFeeEtb
);