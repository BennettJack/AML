using InventoryService.Data.Models;
using InventoryService.Data.Models.Media;

namespace InventoryService.Data.Repositories.Interfaces;

public interface IMediaModelRepository
{
    Task<List<MediaModel>> GetAllMediaItems();
    Task<MediaModel> GetMediaItemById(int id);
    Task AddMediaModelFormatConnection(MediaModelFormatConnection connection);
    Task<MediaModel> GetMediaItemBySerialNumber(long serialNumber);

    Task<List<MediaModelFormatConnection>> GetAllMediaModelFormatConnections();
}