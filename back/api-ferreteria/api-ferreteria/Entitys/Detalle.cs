using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_ferreteria.Entitys
{
    public class Detalle
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int cantidad { get; set; }
        [Required]
        [Column(TypeName = "decimal(20,2)")]
        public decimal precio { get; set; }
        [Required]
        [Column(TypeName = "decimal(20,2)")]
        public decimal importe { get; set; }
        [Required]
        public bool estado { get; set; }
        [Required]
        public int ComprobanteId { get; set; }
        [Required]
        public int ProductoId { get; set; }


    }
}
