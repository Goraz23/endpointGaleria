using System.ComponentModel.DataAnnotations;

namespace Library.Models.Domain
{
    public class Editorial
    {
        [Key]
        public int PkEditorial { get; set; }
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        public int YearFounded { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
