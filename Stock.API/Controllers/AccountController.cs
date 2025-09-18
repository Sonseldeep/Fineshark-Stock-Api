using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stock.API.Dtos.Account.Request;
using Stock.API.Dtos.Account.Response;
using Stock.API.Models;
using Stock.API.Services;

namespace Stock.API.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;

    public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    [HttpPost("api/accounts/register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            var appUser = new AppUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email
            };
            
            var createdUser = await _userManager.CreateAsync(appUser,registerDto.Password ?? throw new InvalidOperationException());

            if (!createdUser.Succeeded)
            {
                return BadRequest(new { errors = createdUser.Errors });
            }
            
            var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

            
            var newUser = new NewUserDto
            {
                UserName = appUser.UserName ?? string.Empty,
                Email = appUser.Email ?? string.Empty,
                Token = _tokenService.CreateToken(appUser)
            };

            
            return roleResult.Succeeded
                ? Ok(newUser)
                : BadRequest(roleResult.Errors);

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}