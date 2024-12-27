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
