using Microsoft.EntityFrameworkCore;
using Stock.API.Data;
using Stock.API.Models;

namespace Stock.API.Repository;

public class PortfolioRepository : IPortfolioRepository
{
    private readonly ApplicationDbContext _context;

    public PortfolioRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Models.Stock>> GetUserPortfolio(AppUser user)
    {
        return await _context.Portfolios.Where(x => x.AppUserId == user.Id)
            .Select(stock => new Models.Stock
            {
                Id = stock.StockId,
                Symbol = stock.Stock.Symbol,
                CompanyName = stock.Stock.CompanyName,
                Purchase = stock.Stock.Purchase,
                LastDiv = stock.Stock.LastDiv,
                Industry = stock.Stock.Industry,
                MarketCap = stock.Stock.MarketCap
            }).ToListAsync();
    }
}