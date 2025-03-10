using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.Domain
{
    public class Book
    {
        [Key]
        public int PkBook { get; set; }
        [Required]
        public string Name { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
		public int FkEditorial { get; set; }

		[ForeignKey("FkEditorial")]
		public Editorial Editorial { get; set; }
		public int FkAuthor { get; set; }

		[ForeignKey("FkAuthor")]
		public Author Author { get; set; }
	}
}
