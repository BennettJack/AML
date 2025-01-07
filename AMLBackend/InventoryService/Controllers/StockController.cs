using System.Net;
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
        [Route("GetMediaStockRecordsByBranch")]
        public async Task<IActionResult> GetMediaStockRecordsByBranch(int mediaId, int branchId)
        {
            var stockRecords = _stockService.GetStockRecords(mediaId, branchId).Result;
            return Ok(stockRecords);
        }
        
        [HttpGet]
        [Route("GetAllMediaStockRecordsByBranch")]
        public async Task<IActionResult> GetAllMediaStockRecordsByBranch(int branchId)
        {
            var stockRecords = _stockService.GetStockRecords(branchId).Result;
            return Ok(stockRecords);
        }
        

        [HttpGet]
        [Route("GetBorrowRecordById")]
        public async Task<IActionResult> GetBorrowRecordById(int id)
        {
            var records = await _stockService.GetBorrowRecordById(id);
            return Ok(records);
        }
        
        [HttpGet]
        [Route("GetBranchBorrowRecordsByDate")]
        public async Task<IActionResult> GetBranchBorrowRecordsByDate(int branchId, DateTime startDate, DateTime endDate)
        {
            if (branchId == 0)
            {
                
            }
            var records = await _stockService.GetBorrowRecordByDateAndBranch(branchId, startDate, endDate);
            return Ok(records);
        }
        
        [HttpGet]
        [Route("GetBranchReserveRecordsByDate")]
        public async Task<IActionResult> GetBranchReserveRecordsByDate(int branchId, DateTime startDate, DateTime endDate)
        {
            var records = await _stockService.GetReserveRecordByDateAndBranch(branchId, startDate, endDate);
            return Ok(records);
        }
        
        [HttpGet]
        [Route("GetBranchBorrowRecordsByMedia")]
        public async Task<IActionResult> GetBranchBorrowRecordsByMedia(int mediaId, int branchId, DateTime startDate, DateTime endDate)
        {
            var records = await _stockService.GetBranchBorrowRecordsByMedia(mediaId, branchId, startDate, endDate);
            return Ok(records);
        }
        
        [HttpGet]
        [Route("GetBranchReserveRecordsByMedia")]
        public async Task<IActionResult> GetBranchReserveRecordsByMedia(int mediaId, int branchId, DateTime startDate, DateTime endDate)
        {
            var records = await _stockService.GetBranchReserveRecordsByMedia(mediaId, branchId, startDate, endDate);
            return Ok(records);
        }
        
    }
        
    
}