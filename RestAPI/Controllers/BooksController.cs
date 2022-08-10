using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Counters;
using RestAPI.Models;
using RestAPI.ViewModels;
using Services.CustomExceptions;
using Services.Services.Contracts;

namespace RestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

//        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var domainBooks = await _booksService.GetAsync();
            return Ok(domainBooks.Select(x => new Book(x)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(Guid id)
        {
            var book = await _booksService.GetByIdAsync(id);
            if (book == null)
                return NotFound();
            return Ok(new Book(book));
        }
        // POST api/books
        [HttpPost]
        public async Task<ActionResult<Book>> Post(AddBookViewModel addBook)
        {
            if (addBook == null || !addBook.Validate())
            {
                return BadRequest();
            }

            var newBook = await _booksService.AddBookAsync(addBook.ToDomainBook(addBook));
            //            var domainBooks = await _booksService.GetAsync();
            //            book.Id = domainBooks.Max(p => p.Id);
            var book = new Book(newBook);

            AddCounter Counter = AddCounter.Initialize();
            book.Counter = Counter.Increment();

            return Ok(book);
        }
        // PUT api/books/
        [HttpPut]
        public async Task<ActionResult<Book>> Put(UpdateBookViewModel book)
        {
            if (book == null || !book.Validate())
            {
                return BadRequest();
            }
            await _booksService.UpdateBookAsync(book.ToDomainBook(book));
            return Ok(book);
        }

        // DELETE api/books/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var book = await _booksService.DeleteBookAsync(id);
                return Ok(book);
            }
            catch(Exception ex)
            {
                if(ex is BookNotFoundException bookException)
                {
                    return NotFound(bookException.Message);
                }
                return StatusCode(500);
            }
        }
/*
        [Authorize]
        [Route("getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

        [Authorize(Roles = "admin")]
        [Route("getrole")]
        public IActionResult GetRole()
        {
            return Ok("Ваша роль: администратор");
        }
*/
    }
}
