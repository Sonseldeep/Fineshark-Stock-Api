namespace Stock.API.Helper;

public class QueryObject
{
    // for searching or filtering 
    public string? Symbol { get; set; } = null!;
    public string? CompanyName { get; set; } = null!;
    
    // for sorting 
    public string? SortBy { get; set; } = null!;
    public bool IsDescending { get; set; } = false;
}