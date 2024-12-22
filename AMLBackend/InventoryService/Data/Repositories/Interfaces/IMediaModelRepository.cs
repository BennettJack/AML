using InventoryService.Data.Models.Media;

namespace InventoryService.Data.Repositories.Interfaces;

public interface IMediaModelRepository
{
    Task<List<MediaModel>> GetAllMediaItems();
}