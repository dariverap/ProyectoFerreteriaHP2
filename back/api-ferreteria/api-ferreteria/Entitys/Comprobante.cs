using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_ferreteria.Entitys
{
    public class Comprobante
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string numero { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime fecha { get; set; }
        [Required]
        [Column(TypeName = "decimal(20,2)")]
        public decimal igv { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string estado { get; set; }

        public Cliente cliente { get; set; }
        public Usuario usuario { get; set; }
        public FormaPago formapago { get; set; }
        public Documento documento { get; set; }

        public List<Detalle> detalle { get; set; }
    }
}
