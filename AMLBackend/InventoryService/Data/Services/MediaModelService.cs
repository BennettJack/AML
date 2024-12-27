using InventoryService.Data.Models;
using InventoryService.Data.Models.Media;
using InventoryService.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Data.Services;

public class MediaModelService(MediaModelRepository _mediaModelRepository)
{
    public async Task<List<MediaModel>> GetAllMediaItems()
    {
        return await _mediaModelRepository.GetAllMediaItems();
    }
    
    public async Task<List<MediaModelFormatConnection>> GetAllMediaModelFormatConnections()
    {
      return  await _mediaModelRepository.GetAllMediaModelFormatConnections();
    }

    public async Task AddMediaModelFormatConnection(MediaModelFormatConnection connection)
    {
        await _mediaModelRepository.AddMediaModelFormatConnection(connection);
    }
}