using InventoryService.Data;
using InventoryService.Data.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public StockController(InventoryDbContext context)
        {
            _context = context;
        }
        
            
        [HttpPost]
        [Route("AddBookStock")]
        public async Task<IActionResult> AddBookStock([FromBody] BookStockUpdateDto bookStockUpdateDto)
        {
            
            await _context.BookStockEntries.Where(e =>
                e.BookFormatConnection.Id == bookStockUpdateDto.BookFormatConnectionId).ExecuteUpdateAsync(
                s => s.SetProperty(e => e.StockCount, 
                    e => bookStockUpdateDto.StockCount));

            await _context.SaveChangesAsync();
            return Ok();
        }
    }

    
}