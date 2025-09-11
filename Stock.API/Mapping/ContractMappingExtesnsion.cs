using Stock.API.Dtos.Comment.Request;
using Stock.API.Dtos.Comment.Response;
using Stock.API.Dtos.Stock.Request;
using Stock.API.Dtos.Stock.Response;
using Stock.API.Models;

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
            MarketCap = stockModel.MarketCap,
            Comments = stockModel.Comments.Select(x => x.ToCommentDto()).ToList()

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


    public static ResponseCommentDto ToCommentDto(this Models.Comment commentModel)
    {
        return new ResponseCommentDto
        {
            Id = commentModel.Id,
            Title = commentModel.Title,
            Content = commentModel.Content,
            CreatedOn = commentModel.CreatedOn,
            StockId = commentModel.StockId

        };
    }
    
    public static Comment ToCommentModel(this CreateRequestCommentDto commentDto, int stockId)
    {
        return new Comment
        {
            Title = commentDto.Title,
            Content = commentDto.Content,
            StockId = stockId

        };
    }
    
    
    
    
    
}