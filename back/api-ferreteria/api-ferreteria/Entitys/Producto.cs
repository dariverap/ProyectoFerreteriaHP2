using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_ferreteria.Entitys
{
    public class Producto
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string nombre { get; set; }
        [Required]
        [StringLength(maximumLength: 10)]
        public string codigo { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string estado { get; set; }
        [Required]
        [Column(TypeName = "decimal(20,2)")]
        public decimal precio { get; set; }

        public Categoria categoria { get; set; }
        public List<Detalle> detalle { get; set; }

    }
}
