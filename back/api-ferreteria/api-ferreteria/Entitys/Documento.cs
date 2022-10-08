using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_ferreteria.Entitys
{
    public class Documento
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string nombre { get; set; }
        public List<Comprobante> comprobante { get; set; }
    }
}
