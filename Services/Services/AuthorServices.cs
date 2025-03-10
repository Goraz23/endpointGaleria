using Library.Context;
using Library.Models.Domain;
using Library.Services.IServices;

namespace Library.Services.Services
{
	public class AuthorServices : IAuthorServices
	{
		private readonly ApplicationDbContext _context;
		public AuthorServices(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<Author> GetAuthors()
		{
			try
			{
				List<Author> authors = _context.Authors.ToList();
				return authors;
			}
			catch (Exception ex)
			{
				throw new Exception("Sucedio un error:" + ex.Message);
			}
		}

		public bool CreateAuthor(Author request)
		{
			try
			{
				Author author = new Author()
				{
					Name = request.Name,
					Nationality = request.Nationality,
					BirthDate = request.BirthDate,
				};

				_context.Authors.Add(author);
				int result = _context.SaveChanges();

				if (result > 0)
				{
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				throw new Exception("Sucedio un error:" + ex.Message);
			}
		}
	}
}
