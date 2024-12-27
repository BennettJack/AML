using InventoryService.Data.Models;

namespace InventoryService.Data.Repositories.Interfaces;

public interface IAttributeRepository
{
    Task<Format> GetFormatById(int id);
    Task<List<Format>> GetAllFormats();
    Task<Genre> GetGenreById(int id);
    Task<List<Genre>> GetAllGenres();
    
}