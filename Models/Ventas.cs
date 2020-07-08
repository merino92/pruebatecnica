using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.Models
{
    public class Ventas
    {
        public int Id { get; set; }
        public string cliente { get; set; }
        public DateTime fecha { get; set; }       
        [Column(TypeName = "decimal(30, 2)")]
        public decimal total { get; set; }
        [ForeignKey("Tiendas")]
        public int idtienda { get; set; }
        public int facturado { get; set; }
        public int borrado { get; set; }
      
    }
}
