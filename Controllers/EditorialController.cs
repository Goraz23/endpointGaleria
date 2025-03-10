using Library.Models.Domain;
using Library.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EditorialController : ControllerBase
	{
		private readonly IEditorialServices _editorialServices;

		public EditorialController(IEditorialServices editorialServices)
		{
			_editorialServices = editorialServices;
		}

		[HttpGet]
		public ActionResult<List<Editorial>> GetEditorials()
		{
			try
			{
				var editorials = _editorialServices.GetEditorials();
				return Ok(editorials);
			}
			catch (Exception)
			{
				return StatusCode(500, "Error interno del servidor.");
			}
		}

		[HttpPost]
		public ActionResult CreateEditorial([FromBody] Editorial editorial)
		{
			try
			{
				bool created = _editorialServices.CreateEditorial(editorial);
				if (!created)
				{
					return BadRequest("No se pudo crear la edutorial.");
				}

				return Ok("Editorial creada exitosamente.");
			}
			catch (Exception)
			{
				return StatusCode(500, "Error interno del servidor.");
			}
		}
	}
}
