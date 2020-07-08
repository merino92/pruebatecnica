using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using prueba.Models;
using prueba.repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prueba.Controllers
{
    public class TiendaController : Controller
    {
        private readonly tiendaRepository tienda = null;

        public TiendaController(tiendaRepository tr)
        {
            tienda = tr;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult List()
        {
            var categorias = tienda.list();
            return Json(categorias);
        } //listar

        [HttpGet]
        public JsonResult ListId([FromQuery(Name = "id")] int id)
        {

            if (id > 0)
            {
                var dato = tienda.listid(id);
                Dictionary<string, string> response = new Dictionary<string, string>();
                response.Add("error", "0");
                response.Add("id", Convert.ToString(dato.Id));
                response.Add("nombre", dato.nombre);
                return Json(response);

            }
            else
            {
                Dictionary<string, string> response = new Dictionary<string, string>();
                response.Add("error", "1");
                response.Add("response", "No se ha encontrado el dato");
                return Json(response);
            }


        } //listar

        [HttpPost]
        public JsonResult add([FromBody]Tiendas data)
        {
            Dictionary<string, string> response = new Dictionary<string, string>();
            if (ModelState.IsValid)
            {
                int create = tienda.create(data);
                if (create > 0)
                {
                    response.Add("error", "0");
                    response.Add("response", "Creado");
                }
                else
                {
                    response.Add("error", "1");
                    response.Add("response", "Intenta Nuevamente");
                }
            }
            else
            {
                response.Add("error", "1");
                response.Add("response", "No valido");
            }
            return Json(response);
        }//crea

        [HttpPut]
        public JsonResult update([FromBody]Tiendas data)
        {
            if (ModelState.IsValid)
            {
                var res = tienda.update(data);
            }
            Dictionary<string, string> response = new Dictionary<string, string>();
            response.Add("error", "0");
            response.Add("response", "Actualizado exitosamente");
            return Json(response);
        }
        [HttpDelete]
        public JsonResult delete([FromBody] Tiendas data)
        {
            Dictionary<string, string> response = new Dictionary<string, string>();
            if (data.Id > 0)
            {
                int d = tienda.delete(data);
                response.Add("error", "0");
                response.Add("response", "Tienda Eliminada");
            }
            else
            {
                response.Add("error", "1");
                response.Add("response", "No valido");
            }
            return Json(response);
        }
    }
}
