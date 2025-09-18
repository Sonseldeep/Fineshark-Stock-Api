using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stock.API.Models;

namespace Stock.API.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<AppUser>(options)
{
    public DbSet<Models.Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }
}