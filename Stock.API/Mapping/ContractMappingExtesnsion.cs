using Stock.API.Dtos.Stock.Request;
using Stock.API.Dtos.Stock.Response;

namespace Stock.API.Mapping;

public static class ContractMappingExtesnsion
{
    public static ResponseStockDto ToStockDto(this Models.Stock stockModel)
    {
        return new ResponseStockDto
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            LastDiv = stockModel.LastDiv,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap

        };
    }

    public static Models.Stock ToStockModel(this CreateRequestDto stockDto)
    {
        return new Models.Stock
        {
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            Purchase = stockDto.Purchase,
            LastDiv = stockDto.LastDiv,
            Industry = stockDto.Industry,
            MarketCap = stockDto.MarketCap
        };
    }
    
    
    
}