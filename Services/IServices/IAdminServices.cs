using Library.DTOs;
using Library.Models.Domain;

namespace Library.Services.IServices
{
	public interface IAdminServices
	{
		public bool CreateAdmin(Admin request);
		public bool Login(LoginDTO request);
	}
}
