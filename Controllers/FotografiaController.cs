using Microsoft.AspNetCore.Mvc;
using Library.Models.Domain;
using Library.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotografiaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FotografiaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/fotografia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fotografia>>> GetFotografias()
        {
            return await _context.Fotografias.ToListAsync();
        }

        // GET: api/fotografia/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Fotografia>> GetFotografia(int id)
        {
            var fotografia = await _context.Fotografias.FindAsync(id);

            if (fotografia == null)
            {
                return NotFound();
            }

            return fotografia;
        }

        // POST: api/fotografia
        [HttpPost]
        public async Task<ActionResult<Fotografia>> PostFotografia(Fotografia fotografia)
        {
            _context.Fotografias.Add(fotografia);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFotografia), new { id = fotografia.PkFotografia }, fotografia);
        }

		// PUT: api/fotografia/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> PutFotografia(int id, Fotografia fotografia)
		{
			var fotografiaExistente = await _context.Fotografias.FindAsync(id);
			if (fotografiaExistente == null)
			{
				return NotFound();
			}

			try
			{
				fotografia.PkFotografia = fotografiaExistente.PkFotografia;

				_context.Entry(fotografiaExistente).CurrentValues.SetValues(fotografia);

				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				return Conflict("Hubo un conflicto de concurrencia. Los datos han sido modificados por otro proceso.");
			}

			return NoContent();
		}

		// DELETE: api/fotografia/{id}
		[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFotografia(int id)
        {
            var fotografia = await _context.Fotografias.FindAsync(id);
            if (fotografia == null)
            {
                return NotFound();
            }

            _context.Fotografias.Remove(fotografia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
