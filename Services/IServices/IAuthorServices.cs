using Library.Models.Domain;

namespace Library.Services.IServices
{
    public interface IAuthorServices
    {
        Task<IEnumerable<Author>> GetAuthors(); 
        Task<Author> GetAuthorById(int id); 
        Task<Author> CreateAuthorAsync(Author author); 
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(int id);
    }
}
