using Library.Models.Domain;

namespace Library.Services.IServices
{
    public interface IGaleriaService
    {
        Task<IEnumerable<Galeria>> GetAllGaleriasAsync();
        Task<Galeria> GetGaleriaByIdAsync(int id);
        Task<Galeria> CreateGaleriaAsync(Galeria galeria);
        Task UpdateGaleriaAsync(Galeria galeria);
        Task DeleteGaleriaAsync(int id);
    }
}
