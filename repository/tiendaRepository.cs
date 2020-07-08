using System;
using System.Collections.Generic;
using System.Linq;
using prueba.data;
using prueba.Models;

namespace prueba.repository
{
    public class tiendaRepository
    {
        private readonly pruebaContext context = null;
        public tiendaRepository(pruebaContext ctx)
        {
            context = ctx;
        }

        public List<Tiendas> list()
        {
            return context.tiendas.ToList();
        }

        public Tiendas listid(int id)
        {
            return context.tiendas.Find(id);
        }

        public int create(Tiendas tienda)
        {
            var newtienda = tienda;
            context.Add(newtienda);
            context.SaveChanges();
            return newtienda.Id;
        }

        public int update(Tiendas tienda)
        {
            var updatienda = context.tiendas.Find(tienda.Id);
            updatienda.nombre = tienda.nombre;
            context.SaveChanges();
            return 0;
        }

        public int delete(Tiendas tienda)
        {
            context.Remove(tienda);
            context.SaveChanges();
            return 0;
        }
    }
}
