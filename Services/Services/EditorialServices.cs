using Library.Context;
using Library.Models.Domain;
using Library.Services.IServices;

namespace Library.Services.Services
{
	public class EditorialServices : IEditorialServices
	{
		private readonly ApplicationDbContext _context;
		public EditorialServices(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<Editorial> GetEditorials()
		{
			try
			{
				List<Editorial> editorials = _context.Editorials.ToList();
				return editorials;
			}
			catch (Exception ex)
			{
				throw new Exception("Sucedio un error:" + ex.Message);
			}
		}

		public bool CreateEditorial(Editorial request)
		{
			try
			{
				Editorial editorial = new Editorial()
				{
					Name = request.Name,
					Country = request.Country,
					YearFounded = request.YearFounded,
				};

				_context.Editorials.Add(editorial);
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
