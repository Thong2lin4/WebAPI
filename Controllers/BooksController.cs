using LAB_LTW_API.Data;
using LAB_LTW_API.Models.DTO;
using LAB_LTW_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LAB_LTW_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        // private readonly IBookstoreServices _BookService;
        // private readonly ILogger<BooksController> _logger; // Inject ILogger
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BooksController> _logger;

        public BooksController(AppDbContext dbContext, IBookRepository bookRepository,
ILogger<BooksController> logger)
        {

            _dbContext = dbContext;
            _bookRepository = bookRepository;
            _logger = logger;
            // _BookService = BookService;
            //_logger = logger; // Inject ILogger
        }
        [HttpGet("get-all-books")]
        [Authorize(Roles = "Read")]
        public IActionResult GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
[FromQuery] string? sortBy, [FromQuery] bool isAscending)
            
        {
            _logger.LogInformation("GetAll Book Action method was invoked");
            _logger.LogWarning("This is a warning log");
            _logger.LogError("This is a error log");

            var allBooks = _bookRepository.GetAllBooks(filterOn, filterQuery, sortBy,
isAscending);
            _logger.LogInformation($"Finished GetAllBook request with data { JsonSerializer.Serialize(allBooks)}"); 
            return Ok(allBooks);
        }
        [HttpGet]
        [Route("get-book-by-id/{id}")]
        public IActionResult GetBookById([FromRoute] int id)
        {
            var bookWithIdDTO = _bookRepository.GetBookById(id);
            return Ok(bookWithIdDTO);
        }
        [HttpPost("and-book")]
        // [ValidateModel]
        [Authorize(Roles = "Write")]
        public IActionResult AddBook([FromBody] AddBookRequestDTO addBookRequestDTO)
        {
            if (ModelState.IsValid)
            {
                var bookAdd = _bookRepository.AddBook(addBookRequestDTO);
                return Ok(bookAdd);
            }
            else return BadRequest(ModelState);
        }

        [HttpPost("add-book")]
        [Authorize(Roles ="Read,Write")]
        public IActionResult Add([FromBody] AddBookRequestDTO addBookRequestDTO) 
        { 
            var bookAdd =_bookRepository.AddBook(addBookRequestDTO);
            return Ok(bookAdd);
        }
        [HttpPut("update-book-by-id/{id}")]
        [Authorize(Roles ="Read,Write")]
        public IActionResult UpdateBookById(int id, [FromBody] AddBookRequestDTO bookDTO)
        {
            var updateBook = _bookRepository.UpdateBookById(id, bookDTO);
            return Ok(updateBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        [Authorize(Roles = "Read,Write")]
        public IActionResult DeleteBookById(int id)
        {
            var deleteBook = _bookRepository.DeleteBookById(id);
            return Ok(deleteBook);
        }

    }
}
