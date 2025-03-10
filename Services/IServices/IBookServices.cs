using Library.Models.Domain;

namespace Library.Services.IServices
{
    public interface IBookServices
    {
		public List<Book> GetBooks();
		public bool CreateBook(Book request);
		public Book GetBook(int id);
		public bool UpdateBook(int id, Book request);
		public bool DeleteBook(int id);
	}
}
