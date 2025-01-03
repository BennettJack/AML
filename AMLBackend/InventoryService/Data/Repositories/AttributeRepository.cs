using InventoryService.Data.Models;
using InventoryService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data.Repositories;

public class AttributeRepository(InventoryDbContext _context) : IAttributeRepository
{
    public Task<Format> GetFormatById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Format>> GetAllFormats()
    {
        return await _context.Formats.ToListAsync();
    }

    public Task<Genre> GetGenreById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Genre>> GetAllGenres()
    {
        return _context.Genres.ToListAsync();
    }
    
    public List<Genre> GetAllGenres2()
    {
        return _context.Genres.ToList();
    }
}