using System.ComponentModel.DataAnnotations;

namespace Stock.API.Dtos.Account.Request;

public class LoginDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}