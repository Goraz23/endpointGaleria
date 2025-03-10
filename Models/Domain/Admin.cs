using System.ComponentModel.DataAnnotations;

namespace Library.Models.Domain
{
	public class Admin
	{
		[Key]
		public int PkAdmin { get; set; }
		[Required]
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
