namespace AddisEats.Api.Models;

public enum OrderStatus
{
    Placed,
    Preparing,
    Ready,
    Delivered,
    Cancelled
}

public class Order
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public string Area { get; set; } = "";
    public string Phone { get; set; } = "";
    public List<OrderLine> Items { get; set; } = new();
    public decimal SubtotalEtb { get; set; }
    public decimal DeliveryFeeEtb { get; set; }
    public decimal TotalEtb { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Placed;
}

public class OrderLine
{
    public int MenuItemId { get; set; }
    public string MenuItemName { get; set; } = "";
    public int Qty { get; set; }
    public decimal UnitPriceEtb { get; set; }
    public decimal LineTotalEtb { get; set; }
}