using System.ComponentModel.DataAnnotations;

namespace Library.Models.Domain
{
    public class Author
    {
        [Key]
        public int PkAuthor { get; set; }

        public string Nombre { get; set; } = string.Empty;  

        public ICollection<Fotografia> Fotografias { get; set; } = new List<Fotografia>(); 
    }
}
