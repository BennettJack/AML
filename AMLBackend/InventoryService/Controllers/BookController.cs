using InventoryService.Data;
using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;
using InventoryService.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly InventoryDbContext _context;
        private readonly BookRepository _bookRepository;

        public BookController(InventoryDbContext context, BookRepository bookRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
        }
        [HttpPost]
        [Route("NewBook")]
        public async Task<IActionResult> NewBook([FromBody] NewBookSubmissionDto bookSubmission)
        {
            var book = new Book
            {
                Title = bookSubmission.Title,
                Description = bookSubmission.Description,
                PublishDate = DateTime.Parse(bookSubmission.PublishDate),
                PageCount = bookSubmission.PageCount,
                SerialNumber = bookSubmission.SerialNumber
            };
            
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();


            /*foreach (var genreId in bookSubmission.GenreIds)
            {
                var bookGenreConnection = new BookGenreConnection
                {
                    Book = await _context.Books.FirstOrDefaultAsync(b => b.SerialNumber == bookSubmission.SerialNumber),
                    Genre = await _context.Genres.FirstOrDefaultAsync(g => g.GenreId == genreId)
                };
                
                await _context.AddAsync(bookGenreConnection);
            }*/
            await _bookRepository.AddBookGenreConnection(bookSubmission.GenreIds, bookSubmission.SerialNumber);

            foreach (var authorId in bookSubmission.AuthorIds)
            {
                var bookAuthorConnection = new BookAuthorConnection
                {
                    Book = await _context.Books.FirstOrDefaultAsync(b => b.SerialNumber == bookSubmission.SerialNumber),
                    Author = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == authorId),
                };

                await _context.AddAsync(bookAuthorConnection);
            }

            foreach (var formatId in bookSubmission.FormatIds)
            {
                var bookFormatConnection = new BookFormatConnection()
                {
                    Book = await _context.Books.FirstOrDefaultAsync(b => b.SerialNumber == bookSubmission.SerialNumber),
                    Format = await _context.Formats.FirstOrDefaultAsync(a => a.FormatId == formatId),
                };

                await _context.AddAsync(bookFormatConnection);
            }
            
            await _context.SaveChangesAsync();

            var formatEntries =
                _context.BookFormatConnections.Where(f => f.Book.SerialNumber == bookSubmission.SerialNumber).ToList();

            foreach (var formatEntry in formatEntries)
            {
                var stockEntry = new BookStockEntry
                {
                    BookFormatConnection = formatEntry,
                    StockCount = 0
                };

                await _context.AddAsync(stockEntry);
            }
            await _context.SaveChangesAsync();
            
            return Ok();
        }
    }
}
