using Microsoft.AspNetCore.Mvc;
using Library.Models.Domain;
using Library.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        // GET: api/categoria/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // POST: api/categoria
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.PkCategoria }, categoria);
        }

        // PUT: api/categoria/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
			var categoriaExistente = await _context.Categorias.FindAsync(id);
			if (categoriaExistente == null)
			{
				return NotFound();
			}

			try
			{
				categoria.PkCategoria = categoriaExistente.PkCategoria;

				_context.Entry(categoriaExistente).CurrentValues.SetValues(categoria);

				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				return Conflict("Hubo un conflicto de concurrencia. Los datos han sido modificados por otro proceso.");
			}

			return NoContent();
		}

        // DELETE: api/categoria/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
