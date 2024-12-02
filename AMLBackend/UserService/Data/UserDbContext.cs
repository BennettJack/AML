using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserService.Data.Models.Users;

namespace UserService.Data;

public class UserDbContext : IdentityDbContext<User>
{
    public UserDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
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
                Name = "CallCentreOperator",
                NormalizedName = "CALLCENTREOPERATOR"
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
                Name = "AMLAdministrator",
                NormalizedName = "AMLADMINISTRATOR"
            },
            new IdentityRole()
            {
                Name = "SystemAdministartor",
                NormalizedName = "SYSTEMADMINISTRATOR"
            },
            new IdentityRole()
            {
                Name = "Member",
                NormalizedName = "MEMBER"
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}