using System.ComponentModel.DataAnnotations;

namespace SaltVenture.API.Models.Request;

public class UserLoginRequest
{
    [Required]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string? Password { get; set; }
}
