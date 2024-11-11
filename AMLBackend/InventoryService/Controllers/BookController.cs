using InventoryService2.Data;
using InventoryService2.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public BookController(InventoryDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("NewBook")]
        public async Task<IActionResult> NewBook([FromBody] Book book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
