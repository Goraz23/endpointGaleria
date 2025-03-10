using Library.Models.Domain;

namespace Library.Services.IServices
{
	public interface IAuthorServices
	{
		public List<Author> GetAuthors();
		public bool CreateAuthor(Author request);
	}
}
