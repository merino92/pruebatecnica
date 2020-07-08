using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using prueba.Models;
using prueba.repository;

namespace prueba.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly categoriaRepository categoria = null;

        public CategoriaController(categoriaRepository ca){
            categoria = ca;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult List(){
            var categorias = categoria.listar();
            return Json(categorias);
        } //listar
        
        [HttpGet]
        public JsonResult ListId([FromQuery(Name = "id")] int id){

            if(id > 0){
                var dato =categoria.listarId(id);
                 Dictionary<string, string> response = new Dictionary<string, string>();
                response.Add("error","0");
                response.Add("id", Convert.ToString(dato.Id));
                response.Add("nombre",dato.nombre);
                return Json(response);

            }else{
                Dictionary<string, string> response = new Dictionary<string, string>();
                response.Add("error","1");
                response.Add("response","No se ha encontrado el dato");
                 return Json(response);
            }
           
           
        } //listar

        [HttpPost]
        public JsonResult add([FromBody]Categorias data){
            Dictionary<string, string> response = new Dictionary<string, string>();
            if(ModelState.IsValid){
            int create = categoria.addCategoria(data);
            if(create > 0){
                response.Add("error","0");
                response.Add("response","Creado");
            }else{
                response.Add("error","1");
                response.Add("response","Intenta Nuevamente");
            }
            }else{
                response.Add("error","1");
                response.Add("response","No valido");
            }
            return Json(response);
        }//crea

        [HttpPut]
        public JsonResult update([FromBody]Categorias data){
            if(ModelState.IsValid){
                var res = categoria.updateCaterorio(data);
            }
            Dictionary<string, string> response = new Dictionary<string, string>();
            response.Add("error","0");
            response.Add("response","Actualizado exitosamente");
            return Json(response);
        }
        [HttpDelete]
        public JsonResult delete([FromBody] Categorias data){
             Dictionary<string, string> response = new Dictionary<string, string>();
             if(data.Id > 0){
                 int d = categoria.delete(data);
                 response.Add("error","0");
                response.Add("response","Categoria Eliminada");
             }else{
                response.Add("error","1");
                response.Add("response","No valido");
             }
             return Json(response);
        }
    }
}
