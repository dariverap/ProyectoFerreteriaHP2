using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace api_ferreteria.Entitys
{
    public class Cliente
    {
        //clave primaria
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(maximumLength:30)]
        public string nombre { get; set; }
        [StringLength(maximumLength: 30)]
        public string apellido { get; set; }
        [Required]
        [StringLength(maximumLength: 12)]
        public string numdocumento { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        public string estado { get; set; }

        public List<Comprobante> comprobante { get; set; }

    }
}
