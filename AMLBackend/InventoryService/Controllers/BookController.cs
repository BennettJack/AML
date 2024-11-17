using InventoryService.Data;
using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public BookController(InventoryDbContext context)
        {
            _context = context;
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
                Publisher = await _context.Publishers.FirstOrDefaultAsync(p => p.PublisherId == bookSubmission.PublisherId),
                PageCount = bookSubmission.PageCount,
                SerialNumber = bookSubmission.SerialNumber
            };
            
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();


            foreach (var genreId in bookSubmission.GenreIds)
            {
                var bookGenreConnection = new BookGenreConnection
                {
                    Book = await _context.Books.FirstOrDefaultAsync(b => b.SerialNumber == bookSubmission.SerialNumber),
                    Genre = await _context.Genres.FirstOrDefaultAsync(g => g.GenreId == genreId)
                };
                
                await _context.AddAsync(bookGenreConnection);
            }


            foreach (var authorId in bookSubmission.AuthorIds)
            {
                var bookAuthorConnection = new BookAuthorConnection
                {
                    Book = await _context.Books.FirstOrDefaultAsync(b => b.SerialNumber == bookSubmission.SerialNumber),
                    Author = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == authorId),
                };

                await _context.AddAsync(bookAuthorConnection);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
