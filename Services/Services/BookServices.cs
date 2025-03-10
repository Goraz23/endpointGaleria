using Library.Context;
using Library.Models.Domain;
using Library.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.Services
{
	public class BookServices : IBookServices
	{
		private readonly ApplicationDbContext _context;
		public BookServices(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<Book> GetBooks()
		{
			try
			{
				List<Book> books = _context.Books.Include(x => x.Editorial).Include(x => x.Author).ToList();
				return books;
			}
			catch (Exception ex)
			{
				throw new Exception("Sucedio un error:" + ex.Message);
			}
		}

		public bool CreateBook(Book request)
		{
			try
			{
				Book book = new Book()
				{
					Name = request.Name,
					ISBN = request.ISBN,
					PublicationYear = request.PublicationYear,
					Pages = request.Pages,
					Price = request.Price,
					FkEditorial = request.FkEditorial,
					FkAuthor = request.FkAuthor,
				};

				_context.Books.Add(book);
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

		public Book GetBook(int id)
		{
			try
			{
				Book result = _context.Books.Find(id);
				//Usuario result = _context.Usuarios.FirstOrDefault(x => x.PkUser == id);
				return result;
			}
			catch (Exception ex)
			{
				throw new Exception("Faltal error: " + ex.Message);
			}
		}

		public bool UpdateBook(int id, Book request)
		{
			try
			{
				Book book = _context.Books.Find(id);
				if (book == null)
				{
					throw new Exception("Usuario no encontrado");
				}

				book.Name = request.Name;
				book.ISBN = request.ISBN;
				book.PublicationYear = request.PublicationYear;
				book.Pages = request.Pages;
				book.Price = request.Price;
				book.FkEditorial = request.FkEditorial;
				book.FkAuthor = request.FkAuthor;

				_context.Books.Update(book);
				int result = _context.SaveChanges();

				return result > 0;
			}
			catch (Exception ex)
			{
				throw new Exception("Sucedió un error: " + ex.Message);
			}
		}

		public bool DeleteBook(int id)
		{
			try
			{
				var book = _context.Books.Find(id);
				if (book == null)
				{
					return false;
				}

				_context.Books.Remove(book);
				int result = _context.SaveChanges();

				return result > 0;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al eliminar el usuario: " + ex.Message);
			}
		}
	}
}
