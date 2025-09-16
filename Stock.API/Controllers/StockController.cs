using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock.API.Data;
using Stock.API.Dtos.Stock.Request;
using Stock.API.Mapping;
using Stock.API.Repository;

namespace Stock.API.Controllers;

[ApiController]
public class StockController : ControllerBase
{
    
    private readonly IStockRepository _repository;

    public StockController( IStockRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("api/stocks")]
    public async  Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var stocks = await _repository.GetAllAsync();
        var response = stocks.Select(x => x.ToStockDto());
        
        return Ok(response);
        
    }

    [HttpGet("api/stocks/{id:int}")]

    public async Task<IActionResult> Get([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var stock = await _repository.GetByIdAsync(id);
        return stock is null 
            ? NotFound()
            : Ok(stock.ToStockDto());
    }

    [HttpPost("api/stocks")]
    public async Task<IActionResult> Create([FromBody] CreateRequestDto stockDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var stockModel = stockDto.ToStockModel();
        await _repository.CreateAsync(stockModel);
        return CreatedAtAction(nameof(Get), new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    [HttpPut("api/stocks/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRequestDto updateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }


        var existingStock = await _repository.UpdateAsync(id, updateDto);
        if (!existingStock )
        {
            return NotFound();
        }
        
        
        return NoContent();
        
        
    }

    [HttpDelete("api/stocks/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var existingStock = await _repository.DeleteAsync(id);
        if (!existingStock )
        {
            return NotFound();
        }
       
        return NoContent();
        
    }
}