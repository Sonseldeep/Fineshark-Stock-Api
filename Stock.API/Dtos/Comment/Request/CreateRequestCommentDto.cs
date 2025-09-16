using System.ComponentModel.DataAnnotations;

namespace Stock.API.Dtos.Comment.Request;

public class CreateRequestCommentDto
{
    [Required]
    [StringLength(280, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 280 characters")]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    [StringLength(2800, MinimumLength = 5, ErrorMessage = "Content must be between 5 and 2800 characters")]
    public string Content { get; set; } = string.Empty;
    
}