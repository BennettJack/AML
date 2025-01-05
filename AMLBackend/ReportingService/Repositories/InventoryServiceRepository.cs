using System.Text.Json.Nodes;
using ReportingService.Repositories.Interfaces;

namespace ReportingService.Repositories;

public class InventoryServiceRepository : IInventoryServiceRepository
{
    private readonly string _inventoryServiceApiAddress;
    private HttpClient _client;
    public InventoryServiceRepository(IConfiguration configuration, HttpClient client)
    {
        _client = client;
        var gatewayAddress = configuration.GetSection("GatewayEndpoints")["GatewayAddress"];
        _inventoryServiceApiAddress =
            gatewayAddress + configuration.GetSection("GatewayEndpoints:ServiceApiAddresses")["InventoryService"];
    }

    public Task Test(){
        Console.WriteLine(_inventoryServiceApiAddress);
        return Task.CompletedTask;
    }

    public async Task<string> GetAllMediaStockRecordsByBranch(int branchId)
    {
        Console.WriteLine(_inventoryServiceApiAddress);
        _client.BaseAddress = new Uri("https://localhost:7254/api/");
        var res = await _client.GetStringAsync("Stock/GetAllMediaStockRecordsByBranch?branchId=1");
        return res;
    }
}