using System.ComponentModel.DataAnnotations;

namespace Library.Models.Domain
{
    public class Author
    {
        [Key]
        public int PkAuthor { get; set; }
        [Required]
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
