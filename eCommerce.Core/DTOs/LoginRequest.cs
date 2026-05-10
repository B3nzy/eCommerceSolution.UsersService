using System.ComponentModel.DataAnnotations;

namespace eCommerce.Core.DTOs;

public record LoginRequest
(
    [Required]
    [EmailAddress]
    string? Email,
    [Required]
    [Length(5,20,ErrorMessage = "Password must be within 5 and 20 length")]
    string? Password
);
