using Library.Models.Domain;
using Library.Context;
using Microsoft.EntityFrameworkCore;
using Library.Services.IServices;

namespace Library.Services
{
    public class FotografiaService : IFotografiaService
    {
        private readonly ApplicationDbContext _context;

        public FotografiaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fotografia>> GetAllFotografiasAsync()
        {
            return await _context.Fotografias.ToListAsync();
        }

        public async Task<Fotografia> GetFotografiaByIdAsync(int id)
        {
            return await _context.Fotografias.FindAsync(id);
        }

        public async Task<Fotografia> CreateFotografiaAsync(Fotografia fotografia)
        {
            _context.Fotografias.Add(fotografia);
            await _context.SaveChangesAsync();
            return fotografia;
        }

        public async Task UpdateFotografiaAsync(Fotografia fotografia)
        {
            _context.Entry(fotografia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFotografiaAsync(int id)
        {
            var fotografia = await _context.Fotografias.FindAsync(id);
            if (fotografia != null)
            {
                _context.Fotografias.Remove(fotografia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
