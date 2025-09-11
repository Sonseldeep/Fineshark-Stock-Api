namespace Stock.API.Dtos.Comment.Request;

public class CreateRequestCommentDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    
}