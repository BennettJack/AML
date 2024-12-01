using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;
using InventoryService.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookRepository _bookRepository;
        private readonly MediaModelRepository _mediaModelRepository;

        public BookController(BookRepository bookRepository, MediaModelRepository mediaModelRepository)
        {
            _bookRepository = bookRepository;
            _mediaModelRepository = mediaModelRepository;
        }
        
        [HttpPost]
        [Route("NewBook")]
        public async Task<IActionResult> NewBook([FromBody] NewBookSubmissionDto bookSubmission)
        {
            try
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
                await _mediaModelRepository.AddMediaModelGenreConnection(bookSubmission.GenreIds,
                    bookSubmission.SerialNumber);
                await _mediaModelRepository.AddMediaModelFormatConnection(bookSubmission.FormatIds,
                    bookSubmission.SerialNumber);
                await _bookRepository.AddBookAuthorConnection(bookSubmission.AuthorIds, bookSubmission.SerialNumber);
                await _mediaModelRepository.SetInitialStock(bookSubmission.SerialNumber);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromBody] BookUpdateDto bookUpdate)
        {
            return Ok();
        }
        
    }
}
