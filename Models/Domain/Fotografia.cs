using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.Domain
{
    [Table("Fotografia")]
    public class Fotografia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkFotografia { get; set; }
        public string Nombre { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public int FkAuthor { get; set; }
        public Author? Author { get; set; }

        public int FkCategoria { get; set; }
        public Categoria? Categoria { get; set; }

        public int FkGaleria { get; set; }
        public Galeria? Galeria { get; set; }
    }
}
