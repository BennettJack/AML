using InventoryService2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService2.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)

    {

    }




        public DbSet<Book> Books { get; set; }

}
}
