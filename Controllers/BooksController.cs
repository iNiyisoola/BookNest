using BookNest.Data;
using BookNest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _context;

        public BooksController(BookDbContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var allBooks = await _context.Books.ToListAsync();
            if (allBooks is not null)
            {
                return Ok(allBooks);
            }
            return NotFound();
        }

        //GET: api/books/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book is not null)
            {
                return Ok(book);
            }
            return NotFound(new { message = "Book not Fount" });
        }


        //POST: api/books/
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

           var newBook = await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBook), new { book.Id }, newBook);
        }


        //PUT: api/books/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, [FromBody] Book updateBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (id != updateBook.Id)
            {
                return BadRequest(new { message = "Book could not be Found." });
            }

            var book = await _context.Books.FindAsync(id);
            if (book is null)
            {
                return NotFound();
            }

            book.Author = updateBook.Author;
            book.Price = updateBook.Price;
            book.PublishedDate = updateBook.PublishedDate;

            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(book);
        }


        //DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book is null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
