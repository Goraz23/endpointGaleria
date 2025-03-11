using Library.Models.Domain;
using Library.Context;
using Microsoft.EntityFrameworkCore;
using Library.Services.IServices;

namespace Library.Services
{
    public class GaleriaService : IGaleriaService
    {
        private readonly ApplicationDbContext _context;

        public GaleriaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Galeria>> GetAllGaleriasAsync()
        {
            // Devuelve todas las galerías de la base de datos.
            return await _context.Galerias.ToListAsync();
        }

        public async Task<Galeria> GetGaleriaByIdAsync(int id)
        {
            // Busca una galería por su ID.
            return await _context.Galerias.FindAsync(id);
        }

        public async Task<Galeria> CreateGaleriaAsync(Galeria galeria)
        {
            // Añade una nueva galería a la base de datos.
            _context.Galerias.Add(galeria);
            await _context.SaveChangesAsync();
            return galeria;
        }

        public async Task UpdateGaleriaAsync(Galeria galeria)
        {
            // Actualiza los datos de una galería existente en la base de datos.
            _context.Entry(galeria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGaleriaAsync(int id)
        {
            // Busca y elimina una galería de la base de datos.
            var galeria = await _context.Galerias.FindAsync(id);
            if (galeria != null)
            {
                _context.Galerias.Remove(galeria);
                await _context.SaveChangesAsync();
            }
        }
    }
}
