using System.ComponentModel.DataAnnotations;

namespace SaltVenture.API.Models.Request;

public class UserUpdateRequest
{
    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
