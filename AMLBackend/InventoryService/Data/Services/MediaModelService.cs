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
}