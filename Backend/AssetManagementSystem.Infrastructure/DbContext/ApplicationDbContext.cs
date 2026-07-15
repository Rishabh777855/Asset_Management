using Microsoft.EntityFrameworkCore;
using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<AssetCategory> AssetCategories { get; set; }

    public DbSet<Asset> Assets { get; set; }

    public DbSet<AssetAssignment> AssetAssignments { get; set; }

    public DbSet<RefreshToken> RefreshTokens { get; set; }
}