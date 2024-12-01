using InventoryService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data.Repositories;

public class MediaModelRepository(InventoryDbContext _context)
{
    public async Task AddMediaModelGenreConnection(List<int> genres, int serialNumber)
    {
        foreach (var genreId in genres)
        {
            var mediaModelGenreConnection = new MediaModelGenreConnection
            {
                Media = await _context.MediaModels.FirstOrDefaultAsync(b => b.SerialNumber == serialNumber),
                Genre = await _context.Genres.FirstOrDefaultAsync(g => g.GenreId == genreId)
            };
                
            await _context.AddAsync(mediaModelGenreConnection);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddMediaModelFormatConnection(List<int> formats, int serialNumber)
    {
        foreach (var formatId in formats)
        {
            var mediaModelFormatConnection = new MediaModelFormatConnection
            {
                Media = await _context.MediaModels.FirstOrDefaultAsync(b => b.SerialNumber == serialNumber),
                Format = await _context.Formats.FirstOrDefaultAsync(f => f.FormatId == formatId)
            };
            
            await _context.AddAsync(mediaModelFormatConnection);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SetInitialStock(int serialNumber)
    {
        var formatEntries =
            _context.MediaModelFormatConnections.Where(f => f.Media.SerialNumber == serialNumber).ToList();
        
        foreach (var formatEntry in formatEntries)
        {
            var stockEntry = new BookStockEntry
            {
                MediaModelFormatConnection = formatEntry,
                StockCount = 0
            };

            await _context.AddAsync(stockEntry);
        }
        
        
        await _context.SaveChangesAsync();
    }
}