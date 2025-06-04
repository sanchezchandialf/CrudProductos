using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Range(0, 1000, ErrorMessage = "El precio debe estar entre 1 y 1000 usd")]
        public decimal Precio { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
