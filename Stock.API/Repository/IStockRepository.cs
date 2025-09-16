using Stock.API.Dtos.Stock.Request;
using Stock.API.Helper;

namespace Stock.API.Repository;

public interface IStockRepository
{
    Task<IEnumerable<Models.Stock>> GetAllAsync( QueryObject query);
    Task<Models.Stock?> GetByIdAsync(int id);
    Task<Models.Stock> CreateAsync(Models.Stock stock);
    Task<bool> UpdateAsync(int id, UpdateRequestDto updateDto);
    Task<bool> DeleteAsync(int id);

    Task<bool> StockExists(int id);
}