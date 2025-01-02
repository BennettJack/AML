using InventoryService.Controllers;
using InventoryService.Data.Models.DTO;
using InventoryService.Data.Repositories.Interfaces;
using InventoryService.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ISTest;

public class StockControllerTest
{
    private readonly Mock<IStockService> _mockStockService;

    public StockControllerTest()
    {
        _mockStockService = new Mock<IStockService>();
    }

    [Fact]
    public async Task TransferStockOkRequest()
    {
        StockController controller = new StockController(_mockStockService.Object);
        var stockUpdate = new StockTransferDto
        {
            CurrentBranchId = 1,
            TargetBranchId = 1,
            StockUpdates = new List<StockUpdate>
            {
                new StockUpdate
                {
                    MediaModelFormatConnectionId = 1,
                    StockToTransfer = 1
                }
            }
        };

        var res = await controller.TransferStock(stockUpdate);
        
        Assert.NotNull(res);

    }
}