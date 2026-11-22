namespace AddisEats.OrderBook.Models;

public class Order
{
    public int Id { get; set; }

    public string CustomerName { get; set; }

    public string Area { get; set; }

    public List<OrderLine> Lines { get; set; }

    public DateTime PlacedOn { get; set; }

    public decimal Total => Lines.Sum(line => line.Subtotal);

    public Order(
        int id,
        string customerName,
        string area,
        List<OrderLine> lines)
    {
        if (lines.Count == 0)
        {
            throw new ArgumentException("An order must contain at least one item.");
        }

        Id = id;
        CustomerName = customerName;
        Area = area;
        Lines = lines;
        PlacedOn = DateTime.Now;
    }
}