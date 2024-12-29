using InventoryService.Data;
using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;
using InventoryService.Data.Services;
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
        private readonly StockService _stockService;

        public StockController(InventoryDbContext context, StockService stockService)
        {
            _context = context;
            _stockService = stockService;
        }
        
            
        [HttpPost]
        [Route("UpdateStock")]
        public async Task<IActionResult> UpdateStock([FromBody] List<StockUpdateDto> stockUpdateDto)
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
        
        [HttpPost]
        [Route("TransferStock")]
        public async Task<IActionResult> TransferStock([FromBody] StockTransferDto stockTransfer)
        {
            await _stockService.TransferStock(stockTransfer);
            return Ok();
        }

        [HttpGet]
        [Route("GetMediaStockRecords")]
        public async Task<List<BranchStockRecordDto>> GetMediaStockRecords(int mediaId, int branchId)
        {
            var stockRecords = _stockService.GetStockRecords(mediaId, branchId).Result;
            return stockRecords;
        }

        [HttpGet]
        [Route("Test")]
        public async Task<List<MediaModelFormatConnection>> Test()
        {
            var test =  _context.MediaModelFormatConnections.Include(m => m.Format).Include(m => m.MediaModel).Where(m => m.MediaModel.MediaModelId == 3).ToListAsync().Result;
            return test;
        }
        
        
    }
        
    
}