using Microsoft.EntityFrameworkCore;
using Stock.API.Data;
using Stock.API.Dtos.Stock.Request;

namespace Stock.API.Repository;

public class StockRepository : IStockRepository
{
    private readonly ApplicationDbContext _context;

    public StockRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Models.Stock>> GetAllAsync()
    {
        return await _context.Stocks.AsNoTracking().ToListAsync();
    }

    
    public async Task<Models.Stock?> GetByIdAsync(int id)
    {
        return await _context.Stocks.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Models.Stock> CreateAsync(Models.Stock stock)
    {
        await _context.Stocks.AddAsync(stock);
        await _context.SaveChangesAsync();
        return stock;
    }

    public async Task<bool> UpdateAsync(int id, UpdateRequestDto updateDto)
    {
        var existingStock = await _context.Stocks.SingleOrDefaultAsync(x => x.Id == id);
        if (existingStock is null)
        {
            return false;
        }
        
        existingStock.Symbol = updateDto.Symbol;
        existingStock.CompanyName = updateDto.CompanyName;
        existingStock.Purchase = updateDto.Purchase;
        existingStock.LastDiv = updateDto.LastDiv;
        existingStock.Industry = updateDto.Industry;
        existingStock.MarketCap = updateDto.MarketCap;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingStock = await _context.Stocks.SingleOrDefaultAsync(x => x.Id == id);
        if (existingStock is null)
        {
            return false;
        }

        _context.Stocks.Remove(existingStock);
        await _context.SaveChangesAsync();
        return true;
    }
}
