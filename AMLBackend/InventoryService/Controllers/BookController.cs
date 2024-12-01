using InventoryService.Data;
using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;
using InventoryService.Data.Models.Media;
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
        private readonly MediaModelRepository _mediaModelRepository;

        public BookController(InventoryDbContext context, BookRepository bookRepository, MediaModelRepository mediaModelRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
            _mediaModelRepository = mediaModelRepository;
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

            await _bookRepository.AddNewBook(book);
            await _mediaModelRepository.AddMediaModelGenreConnection(bookSubmission.GenreIds, bookSubmission.SerialNumber);
            await _mediaModelRepository.AddMediaModelFormatConnection(bookSubmission.FormatIds,
                bookSubmission.SerialNumber);
            await _bookRepository.AddBookAuthorConnection(bookSubmission.AuthorIds, bookSubmission.SerialNumber);
            await _mediaModelRepository.SetInitialStock(bookSubmission.SerialNumber);
            
            return Ok();
        }
    }
}
