using InventoryService.Data;
using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;
using InventoryService.Data.Repositories.Interfaces;
using InventoryService.Data.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }
        
            
        [HttpPost]
        [Route("UpdateStock")]
        public async Task<IActionResult> UpdateStock([FromBody] List<StockUpdateDto> stockUpdateDto)
        {
            return Ok();
        }
        
        [HttpPost]
        [Route("TransferStock")]
        public async Task<IActionResult> TransferStock([FromBody] StockTransferDto stockTransfer)
        {
            try
            {
                await _stockService.TransferStock(stockTransfer);
                return Ok();
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (NullReferenceException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Route("GetMediaStockRecords")]
        public async Task<List<BranchStockRecordDto>> GetMediaStockRecords(int mediaId, int branchId)
        {
            var stockRecords = _stockService.GetStockRecords(mediaId, branchId).Result;
            return stockRecords;
        }
        
        [HttpGet]
        [Route("GetAllMediaStockRecordsByBranch")]
        public async Task<List<BranchStockRecordDto>> GetAllMediaStockRecordsByBranch(int branchId)
        {
            var stockRecords = _stockService.GetStockRecords(branchId).Result;
            return stockRecords;
        }

        [HttpGet]
        [Route("GetBorrowRecordById")]
        public async Task<BorrowRecord> GetBorrowRecordById(int id)
        {
            return await _stockService.GetBorrowRecordById(id);
        }
        
    }
        
    
}