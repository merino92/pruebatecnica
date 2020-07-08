using Microsoft.EntityFrameworkCore;
using prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.data
{
    public class pruebaContext : DbContext
    {
        public pruebaContext(DbContextOptions<pruebaContext> options)
        : base(options) { }

        public DbSet<Tiendas> tiendas { get; set; }
        public DbSet<Categorias> categorias { get; set; }
        public DbSet<Productos> productos { get; set; }
        public DbSet<Ventas> ventas { get; set; }
        public DbSet<Ventasdetalle> ventasdetalles { get; set; }
      
    }
}
