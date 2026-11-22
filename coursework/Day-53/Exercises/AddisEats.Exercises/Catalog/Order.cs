namespace AddisEats.Catalog;

public record Order(
    int Id,
    string CustomerName,
    string Area,
    decimal Subtotal,
    DateTime PlacedOn
);