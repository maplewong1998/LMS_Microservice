using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Books.API.Data;
using Books.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("ClientIdPolicy")]
    public class BooksController : ControllerBase
    {
        private readonly BooksAPIContext _context;

        public BooksController(BooksAPIContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        {
            return await _context.Book.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(string id)
        {
            var book = await _context.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(string id, Book book)
        {
            if (id != book.id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Book.Add(book);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookExists(book.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBook", new { id = book.id }, book);
        }

        // DELETE: api/Books/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(string id)
        {
            return _context.Book.Any(e => e.id == id);
        }
    }
}
