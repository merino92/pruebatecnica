using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using prueba.Models;
using prueba.repository;

namespace prueba.Controllers
{
    public class ProductoController : Controller
    {
        private readonly productoRepository producto = null;
        public ProductoController(productoRepository pr)
        {
            producto = pr;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult list()
        {
            return Json(producto.Listar());
            //return Json("{}");
        } //lista los datos

        [HttpGet]
        public JsonResult listid([FromQuery(Name = "id")]int id)
        {
            if(id > 0)
            {
                var productos = producto.ListId(id);
                Dictionary<string, string> response = new Dictionary<string, string>();
                response.Add("error", "0");
                response.Add("id", Convert.ToString(productos.Id));
                response.Add("codigo", Convert.ToString(productos.codigo));
                response.Add("nombre", Convert.ToString(productos.nombre));
                response.Add("existencia", Convert.ToString(productos.existencia));
                response.Add("precio", Convert.ToString(productos.precio));
                response.Add("categoriaid", Convert.ToString(productos.categoriaid));

                return Json(response);
               

            }
            else
            {
                Dictionary<string, string> response = new Dictionary<string, string>();
                response.Add("error", "1");
                response.Add("response", "Error en el identificador");
                return Json(response);
            }
        }//busca por id

        [HttpPost]
        public JsonResult add([FromBody] Productos newproduct)
        {
            int res = producto.add(newproduct);
            Dictionary<string, string> response = new Dictionary<string, string>();
           // int res = 0;
            if (res  > 0)
            {
                response.Add("error", "0");
                response.Add("response", "Producto Creado");
            }
            else
            {
                response.Add("error", "1");
                response.Add("response", "Algo Ocurrio ");
            }

            return Json(response);
        } //crea nuevo producto.

        [HttpPut]
        public JsonResult update([FromBody] Productos update)
        {
            int res = producto.update(update);
            Dictionary<string, string> response = new Dictionary<string, string>();
            response.Add("error", "0");
            response.Add("response", "Producto Actualizado");
            return Json(response);
        }

        [HttpDelete]
        public JsonResult delete([FromBody] Productos delete)
        {
            int res = producto.delete(delete);
            Dictionary<string, string> response = new Dictionary<string, string>();
            response.Add("error", "0");
            response.Add("response", "Producto Eliminado");
            return Json(response);
        }
        
    }
}
