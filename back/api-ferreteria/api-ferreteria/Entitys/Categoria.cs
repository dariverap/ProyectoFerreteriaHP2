using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_ferreteria.Entitys
{
    public class Categoria
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string nombre { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public bool estado { get; set; }
        public List<Producto> producto { get; set; }
    }
}
