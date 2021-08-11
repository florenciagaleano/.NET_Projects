using SistemaWebVuelos.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Models
{
    [Table("Vuelo")]
    public class Vuelo
    {
        [Key]
        public int Id { get; set; }
        [Required]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        [CheckValidDate]
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Destino { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Origen { get; set; }
        [Required]
        [StringLength(20)]
        public string Matricula { get; set; }
    }
}