using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

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
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }
        [Required]
        [Column(TypeName = "decimal(20,2)")]
        public decimal igv { get; set; }
        [Required]
        [Column(TypeName = "decimal(20,2)")]
        public decimal subtotal { get; set; }
        [Required]
        [Column(TypeName = "decimal(20,2)")]
        public decimal total { get; set; }
        [Required]
        public bool estado { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public int FormaPagoId { get; set; }
        [Required]
        public int DocumentoId { get; set; }

        public List<Detalle> detalle { get; set; }
    }
}
