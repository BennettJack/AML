using InventoryService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data.Repositories;

public class BookRepository(InventoryDbContext _context)
{
    public async Task AddBookGenreConnection(List<int> genres, int serialNumber)
    {
        foreach (var genreId in genres)
        {
            var bookGenreConnection = new BookGenreConnection
            {
                Book = await _context.Books.FirstOrDefaultAsync(b => b.SerialNumber == serialNumber),
                Genre = await _context.Genres.FirstOrDefaultAsync(g => g.GenreId == genreId)
            };
                
            await _context.AddAsync(bookGenreConnection);
            await _context.SaveChangesAsync();
        }
    }
}