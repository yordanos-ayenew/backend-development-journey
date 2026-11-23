using System.ComponentModel.DataAnnotations;
using AddisEats.Api.Validation;

namespace AddisEats.Api.Dtos;

public class CreateOrderRequest : IValidatableObject
{
    [Range(1, int.MaxValue, ErrorMessage = "Restaurant ID must be greater than zero.")]
    public int RestaurantId {get; set;}

    [Required(ErrorMessage = "Delivery area is required.")]
    [StringLength(60, MinimumLength = 2,
        ErrorMessage = "Area must contain between 2 and 60 characters.")]
    public string Area {get; set;} = "";

    [Required(ErrorMessage = "Customer phone number is required.")]
    [EthiopianMobile]
    public string Phone { get; set; } = "";

    [Required(ErrorMessage = "Order items are required.")]
    [MinLength(1, ErrorMessage = "An order needs at least one item.")]
    public List<OrderLineRequest> Items { get; set; } = new();

    public bool IsScheduled { get; set; }

    public DateTime? ScheduledFor { get; set; }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        if (IsScheduled && ScheduledFor is null)
        {
            yield return new ValidationResult(
                "A scheduled order requires a delivery time.",
                new[] { nameof(ScheduledFor) }
            );
        }
    }
}
