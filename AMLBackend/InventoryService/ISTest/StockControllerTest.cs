using InventoryService.Controllers;
using InventoryService.Data.Models.DTO;
using InventoryService.Data.Repositories.Interfaces;
using InventoryService.Data.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ISTest;

public class StockControllerTest
{
    private readonly Mock<IStockRepository> _mockStockRepository;
    private readonly StockService _stockService;
    private readonly StockController _controller;

    public StockControllerTest()
    {
        _mockStockRepository = new Mock<IStockRepository>();
        _stockService = new StockService(_mockStockRepository.Object);
        _controller = new StockController(_stockService);
    }

    //Ensure providing a valid StockTransferDto to TransferStock endpoint returns OkResult
    [Fact]
    public async Task TransferStockOkRequest()
    {
        //Arrange
        var stockUpdate = GetDemoStockTransferDto();
        
        //Act
        var res = await _controller.TransferStock(stockUpdate);
     
        //Assert
        Assert.NotNull(res);
        var okResult = Assert.IsType<OkResult>(res);
        Assert.Equal(200, okResult.StatusCode); 
    }

    //Ensures an error is thrown if TransferStockDto has a zero value in it
    //As every field is an ID, they cannot be 0
    [Fact]
    public async Task TransferStockContainsZeroValue()
    {
        //Arrange
        var stockUpdate = GetDemoStockTransferDto();
        stockUpdate.CurrentBranchId = 0;
        
        //Act
        var res = await _controller.TransferStock(stockUpdate);
        //Assert
        Assert.NotNull(res);
        var resType = Assert.IsType<BadRequestObjectResult>(res);
        Assert.Equal(400, resType.StatusCode);
        Assert.Equal("Error: Request contains a zero value", resType.Value);
        
        
    }

    private StockTransferDto GetDemoStockTransferDto()
    {
        var stockUpdate = new StockTransferDto
        {
            CurrentBranchId = 1,
            TargetBranchId = 2,
            StockUpdates = new List<StockUpdate>
            {
                new StockUpdate
                {
                    MediaModelFormatConnectionId = 1,
                    StockToTransfer = 1
                }
            }
        };

        return stockUpdate;
    }
    
}