using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult Form()
        {
            ML.Usuario usuario = new ML.Usuario();
            
            return View(new ML.Usuario());
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result resultUsuario = BL.Usuario.Add(usuario);
            return View();
        }
    }
}