using prueba.data;
using prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.repository
{
    public class categoriaRepository
    {
        private readonly pruebaContext context = null;
        public categoriaRepository(pruebaContext contexto)
        {
            context = contexto;
        }

        public List<Categorias> listar(){
            var categorias = context.categorias.ToList();
            return categorias;
        } //lista las categorias

        public Categorias listarId(int id){
            var datos = context.categorias.Single(b => b.Id == id);
            return datos;
        }
        public int addCategoria(Categorias categorias)
        {
            var nuevaCategoria = new Categorias{
                nombre =categorias.nombre
            };
            context.categorias.Add(nuevaCategoria);
            context.SaveChanges();
            return nuevaCategoria.Id;
        } //crea una nueva categoria

        public string updateCaterorio(Categorias categoria){
            var update = context.categorias.Single(b => b.Id == categoria.Id);
            update.nombre = categoria.nombre;
            context.SaveChanges();
            return "exito";
        }//actualiza categoria

        public  int delete(Categorias categoria){
            var categoriaDelete = categoria;
            context.categorias.Remove(categoriaDelete);
            context.SaveChanges();
            return 0;
        }//elimina la categoria
    }
}
