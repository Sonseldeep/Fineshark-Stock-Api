using Stock.API.Dtos.Stock.Request;
using Stock.API.Repository;

namespace Stock.API.Service;

public class StockService : IStockService
{
    private readonly IStockRepository _stockRepository;

    public StockService(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public async Task<IEnumerable<Models.Stock>> GetAllAsync()
    {
        return await _stockRepository.GetAllAsync();
    }

    public async Task<Models.Stock?> GetByIdAsync(int id)
    {
        return await _stockRepository.GetByIdAsync(id);
    }

    public async Task<Models.Stock> CreateAsync(Models.Stock stock)
    {
        return await _stockRepository.CreateAsync(stock);
    }

    public async Task<bool> UpdateAsync(int id, UpdateRequestDto updateDto)
    {
        return await _stockRepository.UpdateAsync(id, updateDto);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _stockRepository.DeleteAsync(id);
    }
}