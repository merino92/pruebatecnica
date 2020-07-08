using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.Models
{
    public class Ventasdetalle
    {
        public int Id { get; set; }
        public int cantidad { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal precio { get; set; }
        [Column(TypeName = "decimal(30, 2)")] 
        public decimal subtotal { get; set; }
        [ForeignKey("Ventas")]
        public int idventa { get; set; }
        [ForeignKey("Productos")]
        public int idproducto { get; set; }
        
    }
}
