using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();


            ML.Result result = BL.Materia.GetAllLinQ();

            if (result.Correct)
            {
                materia.Materias = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al traer los registros de materias" + result.ErrorMessage;
            }

            return View(materia);
        }


        //form

        [HttpGet]
        public ActionResult Form()
        {
            return View(new ML.Materia());
        }
    }
}