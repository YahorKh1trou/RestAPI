using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Counters;
using RestAPI.Models;
using RestAPI.ViewModels;
using Services.Services.Contracts;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var domainBooks = await _booksService.GetAsync();
            return Ok(domainBooks.Select(x => new Book(x) { Birthdate = x.Birthdate.ToString("dd.MM.yyyy") }));
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _booksService.GetByIdAsync(id);
            if (book == null)
                return NotFound();
            return Ok(new Book(book) { Birthdate = book.Birthdate.ToString("dd.MM.yyyy") });
        }
        // POST api/books
        [HttpPost]
        public async Task<ActionResult<Book>> Post(AddBookViewModel book)
        {
            if (book == null || !book.Validate())
            {
                return BadRequest();
            }

            AddCounter Counter = AddCounter.Initialize();
            book.Counter = Counter.Increment();

            await _booksService.AddBookAsync(book.ToDomainBook(book));
            var domainBooks = await _booksService.GetAsync();
            book.Id = domainBooks.Max(p => p.Id);

            return Ok(book);
        }
        // PUT api/books/
        [HttpPut]
        public async Task<ActionResult<Book>> Put(UpdateBookViewModel book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            await _booksService.UpdateBookAsync(book.ToDomainBook(book));
            return Ok(book);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _booksService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _booksService.DeleteBookAsync(book);
            return Ok(book);
        }

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

    }
}
