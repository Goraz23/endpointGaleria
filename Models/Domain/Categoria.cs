using System.ComponentModel.DataAnnotations;

namespace Library.Models.Domain
{
    public class Categoria
    {
        [Key]
        public int PkCategoria { get; set; }

        public string NombreCategoria { get; set; } = string.Empty;

        public ICollection<Fotografia> Fotografias { get; set; } = new List<Fotografia>();
    }
}
