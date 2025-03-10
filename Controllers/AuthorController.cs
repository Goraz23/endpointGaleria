using Library.Models.Domain;
using Library.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthorController : ControllerBase
	{
		private readonly IAuthorServices _authorServices;

		public AuthorController(IAuthorServices authorServices)
		{
			_authorServices = authorServices;
		}

		[HttpGet]
		public ActionResult<List<Author>> GetAuthors()
		{
			try
			{
				var authors = _authorServices.GetAuthors();
				return Ok(authors);
			}
			catch (Exception)
			{
				return StatusCode(500, "Error interno del servidor.");
			}
		}

		[HttpPost]
		public ActionResult CreateAuthor([FromBody] Author author)
		{
			try
			{
				bool created = _authorServices.CreateAuthor(author);
				if (!created)
				{
					return BadRequest("No se pudo crear el autor.");
				}

				return Ok("Autor creado exitosamente.");
			}
			catch (Exception)
			{
				return StatusCode(500, "Error interno del servidor.");
			}
		}
	}
}
