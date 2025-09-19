using Stock.API.Models;

namespace Stock.API.Repository;

public interface IPortfolioRepository
{
    Task<List<Models.Stock>> GetUserPortfolio(AppUser user);
    
}