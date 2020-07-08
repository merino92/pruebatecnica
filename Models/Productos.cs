using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.Models
{
    public class Productos
    {
        public int Id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int existencia { get; set; }

        [Column(TypeName = "decimal(30, 2)")]
        public decimal precio { get; set; }
        [ForeignKey("Categoria")]
        public int categoriaid { get; set; }
       
    }
}
