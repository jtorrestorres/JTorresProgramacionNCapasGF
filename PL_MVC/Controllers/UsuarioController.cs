using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();

            return View(new ML.Usuario());
        }

        // GET: Usuario
        [HttpGet]
        public ActionResult Form()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Sexo = 'F';
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result resultUsuario = BL.Usuario.Add(usuario);
            return View();
        }

        public JsonResult UpdateStatus(int IdUsuario, bool Status)
        {
            ML.Result resultUsuario = BL.Usuario.Add(new ML.Usuario());
            
            return Json(resultUsuario);
        }
    }
}