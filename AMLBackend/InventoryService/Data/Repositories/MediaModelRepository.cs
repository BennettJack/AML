using InventoryService.Data.Branch;
using InventoryService.Data.Models;
using InventoryService.Data.Models.Media;
using InventoryService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data.Repositories;

public class MediaModelRepository(InventoryDbContext _context) : IMediaModelRepository
{
    public async Task<List<MediaModel>> GetAllMediaItems()
    {
        return await _context.MediaModels.ToListAsync();
    }

    public async Task<MediaModel> GetMediaItemById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddMediaModelFormatConnection(MediaModelFormatConnection connection)
    {
        await _context.MediaModelFormatConnections.AddAsync(connection);
        await _context.SaveChangesAsync();
    }

    public async Task<MediaModel> GetMediaItemBySerialNumber(long serialNumber)
    {
        throw new NotImplementedException();
    }

    public async Task<List<MediaModelFormatConnection>> GetAllMediaModelFormatConnections()
    {
       return await _context.MediaModelFormatConnections.ToListAsync();
    }
}