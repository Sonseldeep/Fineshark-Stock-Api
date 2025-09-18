using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stock.API.Models;

namespace Stock.API.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<AppUser>(options)
{
    public DbSet<Models.Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = "B6A6C99A-7C19-4BE8-B7B6-123456789ABC",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "9F2F43E3-5B0D-4C5D-9B4E-987654321DEF",
                Name = "User",
                NormalizedName = "USER"
            },

        };
        builder.Entity<IdentityRole>().HasData(roles);

    }
}