using InventoryService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data.Repositories;

public class BookRepository(InventoryDbContext _context)
{
    public async Task AddNewBook(Book book)
    {
        _context.AddAsync(book);
        _context.SaveChangesAsync();
    }
    public async Task AddBookAuthorConnection(List<int> authors, int serialNumber)
    {
        foreach (var authorId in authors)
        {
            var bookAuthorConnection = new BookAuthorConnection()
            {
                Book = await _context.Books.FirstOrDefaultAsync(b => b.SerialNumber == serialNumber),
                Author = await _context.Authors.FirstOrDefaultAsync(g => g.AuthorId == authorId)
            };
                
            await _context.AddAsync(bookAuthorConnection);
            await _context.SaveChangesAsync();
        }
    }
}