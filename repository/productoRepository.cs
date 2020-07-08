using prueba.data;
using prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.repository
{
    public class productoRepository
    {
        private readonly pruebaContext context = null;
        public productoRepository(pruebaContext contexto)
        {
            context = contexto;
        }

        public List<Productos> Listar()
        {
            var productos = context.productos.ToList();
            return productos;
        }//lista los productos

        public Productos ListId(int id) {

            var producto = context.productos.Find(id);
            return producto;
        }//busca por id

        public int add(Productos producto)
        {
            var newProduct = new Productos
            {
                codigo = producto.codigo,
                nombre = producto.nombre,
                categoriaid = producto.categoriaid,
                existencia = producto.existencia,
                precio = producto.precio
            };
            context.Add(newProduct);
            context.SaveChanges();
            return newProduct.Id;
        }//crea el producto

        public int update(Productos producto)
        {
            var Updateproducto = context.productos.Find(producto.Id);
            Updateproducto.codigo = producto.codigo;
            Updateproducto.nombre = producto.nombre;
            Updateproducto.existencia = producto.existencia;
            Updateproducto.precio = producto.precio;
            Updateproducto.categoriaid = producto.categoriaid;
            context.SaveChanges();
            return 0;
        }//actualiza los datos del producto

        public int delete(Productos producto)
        {
            var delete = producto;
            context.productos.Remove(delete);
            context.SaveChanges();
            return 0;


        }//elimina producto
    }
}
