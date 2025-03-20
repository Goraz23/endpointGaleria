using Microsoft.AspNetCore.Mvc;
using Library.Models.Domain;
using Library.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaleriaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GaleriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/galeria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Galeria>>> GetGalerias()
        {
            return await _context.Galerias.ToListAsync();
        }

        // GET: api/galeria/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Galeria>> GetGaleria(int id)
        {
            var galeria = await _context.Galerias.FindAsync(id);

            if (galeria == null)
            {
                return NotFound();
            }

            return galeria;
        }

        // POST: api/galeria
        [HttpPost]
        public async Task<ActionResult<Galeria>> PostGaleria(Galeria galeria)
        {
            _context.Galerias.Add(galeria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGaleria), new { id = galeria.PkGaleria }, galeria);
        }

        // PUT: api/galeria/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGaleria(int id, Galeria galeria)
        {
			var galeriaExistente = await _context.Galerias.FindAsync(id);
			if (galeriaExistente == null)
			{
				return NotFound();
			}

			try
			{
				galeria.PkGaleria = galeriaExistente.PkGaleria;

				_context.Entry(galeriaExistente).CurrentValues.SetValues(galeria);

				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				return Conflict("Hubo un conflicto de concurrencia. Los datos han sido modificados por otro proceso.");
			}

			return NoContent();
		}

        // DELETE: api/galeria/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGaleria(int id)
        {
            var galeria = await _context.Galerias.FindAsync(id);
            if (galeria == null)
            {
                return NotFound();
            }

            _context.Galerias.Remove(galeria);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
