using Microsoft.AspNetCore.Mvc;
using Stock.API.Dtos.Comment.Request;
using Stock.API.Mapping;
using Stock.API.Repository;

namespace Stock.API.Controllers;

[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _repository;
    private readonly IStockRepository _stockRepository;

    public CommentController(ICommentRepository repository, IStockRepository stockRepository)
    {
        _repository = repository;
        _stockRepository = stockRepository;
    }

    [HttpGet("api/comments")]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _repository.GetAllAsync();
        var response = comments.Select(x => x.ToCommentDto());
        return Ok(response);
    }

    [HttpGet("api/comments/{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var comment = await _repository.GetByIdAsync(id);
        return comment is null
            ? NotFound()
            : Ok(comment.ToCommentDto());
    }

    [HttpPost("api/comments/{stockId:int}")]
    public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateRequestCommentDto commentDto)
    {
        var isStockExist = await _stockRepository.StockExists(stockId);
        if (!isStockExist)
        {
            return BadRequest("Stock does not exist.");
        }

        var commentModel = commentDto.ToCommentModel(stockId);
        await _repository.CreateAsync(commentModel);
        return CreatedAtAction(nameof(Get),new {id = commentModel.Id},commentModel.ToCommentDto());
    }

    [HttpPut("api/comments/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRequestCommentDto updateDto)
    {
        var comment = await _repository.UpdateAsync(id,updateDto.ToCommentModel());
    }
}