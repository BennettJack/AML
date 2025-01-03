using System.Data.Entity.Infrastructure;
using InventoryService.Controllers;
using InventoryService.Data;
using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;
using InventoryService.Data.Repositories;
using InventoryService.Data.Repositories.Interfaces;
using InventoryService.Data.Services;
using Microsoft.EntityFrameworkCore;
using MockQueryable;
using Moq;

namespace ISTest;

public class StockServiceTest
{
    private readonly Mock<IStockRepository> _mockStockRepository;
    private readonly StockService _stockService;

    public StockServiceTest()
    {
        _mockStockRepository = new Mock<IStockRepository>();
        _stockService = new StockService(_mockStockRepository.Object);
    }
    
    [Fact]
    public async Task GetDemoStockTransferDto()
    {
        {
            /*var data = new List<Genre>
            {
                new Genre { GenreId = 1, GenreName = "Horror" },
                new Genre { GenreId = 2, GenreName = "Action" },
                new Genre { GenreId = 3, GenreName = "Comedy" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Genre>>();
            mockSet.As<IDbAsyncEnumerable<Genre>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Genre>(data.GetEnumerator()));

            mockSet.As<IQueryable<Genre>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Genre>(data.Provider));

            mockSet.As<IQueryable<Genre>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<InventoryDbContext>();
            mockContext.Setup(c => c.Genres).Returns(mockSet.Object);

            var repository = new AttributeRepository(mockContext.Object);
            var genres = await repository.GetAllGenres();
            
            Assert.Equal(3, genres.Count);*/

            var data = new List<Genre>
            {
                new Genre { GenreId = 1, GenreName = "Horror" },
                new Genre { GenreId = 2, GenreName = "Action" },
                new Genre { GenreId = 3, GenreName = "Comedy" }
            };
            
        }
    }
}