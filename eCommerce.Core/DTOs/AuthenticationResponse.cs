namespace eCommerce.Core.DTOs;

public record AuthenticationResponse
(
    Guid UserId,
    string? Email,  
    string? PersonName,
    GenderOptions Gender,
    string? Token,
    bool Success
);
