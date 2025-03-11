using Library.Models.Domain;

namespace Library.Services.IServices
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAllCategoriasAsync();
        Task<Categoria> GetCategoriaByIdAsync(int id);
        Task<Categoria> CreateCategoriaAsync(Categoria categoria);
        Task UpdateCategoriaAsync(Categoria categoria);
        Task DeleteCategoriaAsync(int id);
    }
}
