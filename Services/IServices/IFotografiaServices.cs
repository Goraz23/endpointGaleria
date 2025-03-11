using Library.Models.Domain;

namespace Library.Services.IServices
{
    public interface IFotografiaService
    {
        Task<IEnumerable<Fotografia>> GetAllFotografiasAsync();
        Task<Fotografia> GetFotografiaByIdAsync(int id);
        Task<Fotografia> CreateFotografiaAsync(Fotografia fotografia);
        Task UpdateFotografiaAsync(Fotografia fotografia);
        Task DeleteFotografiaAsync(int id);
    }
}
