//using System;
//using System.Linq;
using BCrypt.Net;
using Library.Context;
using Library.DTOs;
using Library.Models.Domain;
using Library.Services.IServices;

namespace Library.Services.Services
{
	public class AdminServices : IAdminServices
	{
		private readonly ApplicationDbContext _context;
		public AdminServices(ApplicationDbContext context)
		{
			_context = context;
		}

		public bool CreateAdmin(Admin request)
		{
			try
			{
				string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

				Admin admin = new Admin()
				{
					Name = request.Name,
					Email = request.Email,
					Password = hashedPassword,
				};

				_context.Admins.Add(admin);
				int result = _context.SaveChanges();

				return result > 0;
			}
			catch (Exception ex)
			{
				throw new Exception("Sucedió un error: " + ex.Message);
			}
		}

		public bool Login(LoginDTO request)
		{
			try
			{
				Admin? admin = _context.Admins.FirstOrDefault(x => x.Email.ToLower() == request.Email.ToLower());

				if (admin == null)
				{
					return false;
				}

				return BCrypt.Net.BCrypt.Verify(request.Password, admin.Password);
			}
			catch (Exception ex)
			{
				throw new Exception("Error fatal: " + ex.Message);
			}
		}
	}
}
