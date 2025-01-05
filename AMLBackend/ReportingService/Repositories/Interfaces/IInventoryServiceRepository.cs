namespace ReportingService.Repositories.Interfaces;

public interface IInventoryServiceRepository
{
    public Task Test();

    public Task<string> GetAllMediaStockRecordsByBranch(int branchId);
}