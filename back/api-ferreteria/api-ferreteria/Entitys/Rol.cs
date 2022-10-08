using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_ferreteria.Entitys
{
    public class Rol
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string nombre { get; set; }

        public List<Empleado> empleado { get; set; }
    }
}
