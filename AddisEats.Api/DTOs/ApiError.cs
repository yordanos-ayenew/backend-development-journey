namespace AddisEats.Api.Dtos;

public record ApiError(
    string Code,
    string Message
);