using System.ComponentModel.DataAnnotations;

namespace AddisEats.Api.Validation;

public class EtbAmountAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value,
        ValidationContext validationContext)
    {
        if (value is not decimal amount || amount <= 0)
        {
            return new ValidationResult(
                "Amount must be greater than zero."
            );
        }

        if (decimal.Round(amount, 2) != amount)
        {
            return new ValidationResult(
                "Amount cannot have more than two decimal places."
            );
        }

        return ValidationResult.Success;
    }
}