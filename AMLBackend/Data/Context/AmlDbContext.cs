using AmlBackend.Data.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AmlBackend.Data.Context;

public class AmlDbContext : IdentityDbContext<User>
{
    public AmlDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        List<IdentityRole> roles = new()
        {
            new IdentityRole()
            {
                Name = "Member",
                NormalizedName = "MEMBER"
            },
            new IdentityRole()
            {
                Name = "BranchLibrarian",
                NormalizedName = "BRANCHLIBRARIAN"
            },
            new IdentityRole()
            {
                Name = "BranchManager",
                NormalizedName = "BRANCHMANAGER"
            },
            new IdentityRole()
            {
                Name = "CallOperator",
                NormalizedName = "CALLOPERATOR"
            },
            new IdentityRole()
            {
                Name = "Accountant",
                NormalizedName = "ACCOUNTANT"
            },
            new IdentityRole()
            {
                Name = "PurchaseManager",
                NormalizedName = "PURCHASEMANAGER"
            },
            new IdentityRole()
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
            new IdentityRole()
            {
                Name = "SystemAdministrator",
                NormalizedName = "SYSTEMADMINISTRATOR"
            },
        };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}