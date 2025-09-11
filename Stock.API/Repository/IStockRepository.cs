using Stock.API.Dtos.Stock.Request;

namespace Stock.API.Repository;

public interface IStockRepository
{
    Task<IEnumerable<Models.Stock>> GetAllAsync();
    Task<Models.Stock?> GetByIdAsync(int id);
    Task<Models.Stock> CreateAsync(Models.Stock stock);
    Task<bool> UpdateAsync(int id, UpdateRequestDto updateDto);
    Task<bool> DeleteAsync(int id);
}