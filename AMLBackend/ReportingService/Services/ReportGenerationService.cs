using ReportingService.Repositories;
using ReportingService.Repositories.Interfaces;
using ReportingService.Services.Interfaces;

namespace ReportingService.Services;

public class ReportGenerationService : IReportGenerationService
{
    private readonly IInventoryServiceRepository _inventoryServiceRepository;

    public ReportGenerationService(IInventoryServiceRepository rep)
    {
        _inventoryServiceRepository = rep;
    }



    public Task Test()
    {
        return _inventoryServiceRepository.GetAllMediaStockRecordsByBranch(1);
    }
}