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
        [Route("UpdateStock")]
        public async Task<IActionResult> AddBookStock([FromBody] List<StockUpdateDto> stockUpdateDto)
        {
            foreach (var update in stockUpdateDto)
            {
                await _context.StockEntries.Where(e =>
                    e.StockEntryId == update.StockEntryId).ExecuteUpdateAsync(
                    s => s.SetProperty(e => e.StockCount, 
                        e => update.StockCount));
            }


            await _context.SaveChangesAsync();
            return Ok();
        }
    }

    
}