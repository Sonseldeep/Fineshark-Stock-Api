using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stock.API.Extensions;
using Stock.API.Models;
using Stock.API.Repository;

namespace Stock.API.Controllers;

[ApiController]
public class PortfolioController : ControllerBase
{
    private readonly IStockRepository _stockRepository;
    private readonly UserManager<AppUser> _userManager;
    private readonly IPortfolioRepository _portfolioRepository;

    public PortfolioController(IStockRepository stockRepository, UserManager<AppUser> userManager, IPortfolioRepository portfolioRepository)
    {
        _stockRepository = stockRepository;
        _userManager = userManager;
        _portfolioRepository = portfolioRepository;
    }

    [HttpGet("api/portfolio/me")]
    [Authorize]

    public async Task<IActionResult> GetUSerPortfolio()
    {
        var username = User.GetUsername();
        
        var appUser = await _userManager.FindByNameAsync(username);
        
     
        
        var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser!);
        
        return Ok(userPortfolio);
    }
    
}