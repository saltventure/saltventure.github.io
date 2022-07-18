using System.ComponentModel.DataAnnotations;

namespace SaltVenture.API.Models.Request;

public class UserSignUpRequest
{
    [Required]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [MinLength(3)]
    [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Letters and Numbers allowed.")]
    public string? Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string? Password { get; set; }
}
