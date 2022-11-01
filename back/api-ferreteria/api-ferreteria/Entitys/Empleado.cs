using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_ferreteria.Entitys
{
    public class Empleado
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string nombre { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string apellido { get; set; }
        [Required]
        public bool estado { get; set; }
        [Required]
        public int RolId { get; set; }
        public Usuario usuario { get; set; }
        

    }
}
