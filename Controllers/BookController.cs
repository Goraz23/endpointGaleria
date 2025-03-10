using Library.Models.Domain;
using Library.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BookController : ControllerBase
	{
		private readonly IBookServices _bookServices;

		public BookController(IBookServices bookServices)
		{
			_bookServices = bookServices;
		}

		[HttpGet]
		public ActionResult<List<Book>> GetBooks()
		{
			try
			{
				var books = _bookServices.GetBooks();
				return Ok(books);
			}
			catch (Exception)
			{
				return StatusCode(500, "Error interno del servidor.");
			}
		}

		[HttpPost]
		public ActionResult CreateBook([FromBody] Book book)
		{
			try
			{
				bool created = _bookServices.CreateBook(book);
				if (!created)
				{
					return BadRequest("No se pudo crear el libro.");
				}

				return Ok("Libro creado exitosamente.");
			}
			catch (Exception)
			{
				return StatusCode(500, "Error interno del servidor.");
			}
		}

		[HttpPut("{id}")]
		public ActionResult UpdateBook(int id, [FromBody] Book book)
		{
			try
			{
				bool updated = _bookServices.UpdateBook(id, book);
				if (!updated)
				{
					return NotFound("No se encontró el libro para actualizar.");
				}

				return Ok("Libro actualizado exitosamente.");
			}
			catch (Exception)
			{
				return StatusCode(500, "Error interno del servidor.");
			}
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteBook(int id)
		{
			try
			{
				bool deleted = _bookServices.DeleteBook(id);
				if (!deleted)
				{
					return NotFound("No se encontró el libro para eliminar.");
				}

				return Ok("Libro eliminado exitosamente.");
			}
			catch (Exception)
			{
				return StatusCode(500, "Error interno del servidor.");
			}
		}
	}
}
