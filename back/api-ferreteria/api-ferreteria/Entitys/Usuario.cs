using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_ferreteria.Entitys
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string nombre { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string contraseña { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string pregunta { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string respuesta { get; set; }
        [Required]
        public bool estado { get; set; }
        [Required]
        public int EmpleadoId { get; set; }
        public List<Comprobante> comprobante { get; set; }

    }
}
