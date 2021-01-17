using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using BookIssues.API.Models;

namespace BookIssues.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize("ClientIdPolicy")]
    public class BookIssuesController : ControllerBase
    {
        private readonly BookIssuesAPIContext _context;

        public BookIssuesController(BookIssuesAPIContext context)
        {
            _context = context;
        }

        // GET: api/BookIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookIssue>>> GetBooks()
        {
            return await _context.BookIssues.ToListAsync();
        }

        // GET: api/BookIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookIssue>> GetBook(int id)
        {
            var book = await _context.BookIssues.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/BookIssues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookIssue book_issue)
        {
            if (id != book_issue.id)
            {
                return BadRequest();
            }

            _context.Entry(book_issue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookIssueExists(id))
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

        // POST: api/BookIssues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookIssue>> PostBook(BookIssue book)
        {
            _context.BookIssues.Add(book);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookIssueExists(book.id))
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

        // DELETE: api/BookIssues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.BookIssues.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.BookIssues.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookIssueExists(int id)
        {
            return _context.BookIssues.Any(e => e.id == id);
        }
    }
}
