using BranchService.Data.Models.Branch;
using Microsoft.EntityFrameworkCore;
namespace BranchService.Data;

public class BranchDbContext :DbContext
{
    public BranchDbContext(DbContextOptions<BranchDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Branch> Branches { get; set; }
    public DbSet<BranchUserConnection> BranchUserConnections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(x =>{
            x.HasData(
                new Branch { BranchId = 1, BranchLocation = "Sheffield" },
                new Branch { BranchId = 2, BranchLocation = "Chesterfield" },
                new Branch { BranchId = 3, BranchLocation = "Manchester" }
            );
        });
    }
}