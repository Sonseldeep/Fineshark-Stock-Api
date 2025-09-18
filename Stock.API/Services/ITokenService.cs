using Stock.API.Models;

namespace Stock.API.Services;

public interface ITokenService
{
    string CreateToken(AppUser user);
}