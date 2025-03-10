using Library.Models.Domain;
using Library.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Library.DTOs;

namespace Library.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AdminController : ControllerBase
	{
		private readonly IAdminServices _adminServices;

		public AdminController(IAdminServices adminServices)
		{
			_adminServices = adminServices;
		}

		[HttpPost]
		public ActionResult CreateAdmin([FromBody] Admin admin)
		{
			try
			{
				bool created = _adminServices.CreateAdmin(admin);
				if (!created)
				{
					return BadRequest("No se pudo crear al administrador.");
				}

				return Ok("Admin creado exitosamente.");
			}
			catch (Exception)
			{
				return StatusCode(500, "Error interno del servidor.");
			}
		}

		[HttpPost("login")]
		public ActionResult Login([FromBody] LoginDTO request)
		{
			try
			{
				bool created = _adminServices.Login(request);
				if (!created)
				{
					return BadRequest("Datos erroneos.");
				}

				return Ok("Logueado correctamente.");
			}
			catch (Exception)
			{
				return StatusCode(500, "Error interno del servidor.");
			}
		}
	}
}
