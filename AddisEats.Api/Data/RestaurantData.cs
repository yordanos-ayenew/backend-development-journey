using AddisEats.Api.Models;

namespace AddisEats.Api.Data;

public static class RestaurantData
{
    public static List<Restaurant> Items { get; } =
    [
        new() { Id = 1, Name = "Addis Kitchen", Area = "Bole", DeliveryFeeEtb = 40, IsActive = true, OwnerPhone = "0911000001", CommissionRate = 0.10m },
        new() { Id = 2, Name = "Yod Abyssinia", Area = "Bole", DeliveryFeeEtb = 50, IsActive = true, OwnerPhone = "0911000002", CommissionRate = 0.12m },
        new() { Id = 3, Name = "Kategna", Area = "Bole", DeliveryFeeEtb = 45, IsActive = true, OwnerPhone = "0911000003", CommissionRate = 0.10m },
        new() { Id = 4, Name = "Bole Garden", Area = "Bole", DeliveryFeeEtb = 55, IsActive = true, OwnerPhone = "0911000004", CommissionRate = 0.15m },
        new() { Id = 5, Name = "Taitu Restaurant", Area = "Piassa", DeliveryFeeEtb = 60, IsActive = true, OwnerPhone = "0911000005", CommissionRate = 0.10m },
        new() { Id = 6, Name = "Abol Buna", Area = "Piassa", DeliveryFeeEtb = 35, IsActive = true, OwnerPhone = "0911000006", CommissionRate = 0.08m },
        new() { Id = 7, Name = "Sheger Restaurant", Area = "Piassa", DeliveryFeeEtb = 45, IsActive = true, OwnerPhone = "0911000007", CommissionRate = 0.12m },
        new() { Id = 8, Name = "Four Sisters", Area = "Kazanchis", DeliveryFeeEtb = 50, IsActive = true, OwnerPhone = "0911000008", CommissionRate = 0.10m },
        new() { Id = 9, Name = "Effoi Pizza", Area = "Kazanchis", DeliveryFeeEtb = 40, IsActive = true, OwnerPhone = "0911000009", CommissionRate = 0.12m },
        new() { Id = 10, Name = "Genet Restaurant", Area = "Kazanchis", DeliveryFeeEtb = 45, IsActive = true, OwnerPhone = "0911000010", CommissionRate = 0.10m },
        new() { Id = 11, Name = "Mamma Mia", Area = "Megenagna", DeliveryFeeEtb = 55, IsActive = true, OwnerPhone = "0911000011", CommissionRate = 0.15m },
        new() { Id = 12, Name = "Megenagna Kitchen", Area = "Megenagna", DeliveryFeeEtb = 60, IsActive = true, OwnerPhone = "0911000012", CommissionRate = 0.10m }
    ];
}