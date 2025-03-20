using Microsoft.AspNetCore.Mvc;
using Library.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Library.Context; // Cambié Library.Data a Library.Context

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        // GET: api/author/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // POST: api/author
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAuthor), new { id = author.PkAuthor }, author);
        }

        // PUT: api/author/{id}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Author author)
        {
			var authorExistente = await _context.Authors.FindAsync(id);
			if (authorExistente == null)
			{
				return NotFound();
			}

			try
			{
				author.PkAuthor = authorExistente.PkAuthor;

				_context.Entry(authorExistente).CurrentValues.SetValues(author);

				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				return Conflict("Hubo un conflicto de concurrencia. Los datos han sido modificados por otro proceso.");
			}

			return NoContent();
		}



        // DELETE: api/author/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
