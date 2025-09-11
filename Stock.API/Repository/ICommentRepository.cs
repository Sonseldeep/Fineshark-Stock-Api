using Stock.API.Models;

namespace Stock.API.Repository;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetAllAsync();
    Task<Comment?> GetByIdAsync(int id);
    Task<Comment> CreateAsync(Comment commentModel);
    
}