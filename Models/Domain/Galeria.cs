using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.Domain
{
    [Table("Galeria")]
    public class Galeria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkGaleria { get; set; }

        [StringLength(100)]
        public string NombreGaleria { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
