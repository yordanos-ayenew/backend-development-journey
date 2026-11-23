using System.ComponentModel.DataAnnotations;

namespace AddisEats.Api.Dtos;

public class OrderLineRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "Invalid menu item ID.")]
    public int MenuItemId { get; set; }

    [Range(1, 50, ErrorMessage = "Quantity must be between 1 and 50.")]
    public int Qty { get; set; }
}