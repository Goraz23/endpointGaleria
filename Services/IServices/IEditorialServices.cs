using Library.Models.Domain;

namespace Library.Services.IServices
{
	public interface IEditorialServices
	{
		public List<Editorial> GetEditorials();
		public bool CreateEditorial(Editorial request);
	}
}
