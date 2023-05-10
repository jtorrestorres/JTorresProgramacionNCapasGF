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

        [HttpGet] // Mostrar el formulario
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();

            if (IdMateria == null) //add
            {
                return View(materia); //vacio
            }
            else // update
            {
                //Get By Id
                ML.Result result = BL.Materia.GetByLinQ(IdMateria.Value);

                //unboxing
                materia.IdMateria = ((ML.Materia)result.Object).IdMateria;
                materia.Nombre = ((ML.Materia)result.Object).Nombre;
                materia.Costo = ((ML.Materia)result.Object).Costo;
                materia.Creditos = ((ML.Materia)result.Object).Creditos;

                return View(materia);
            }

        }

        [HttpPost] // Recibir los datos del formulario
        public ActionResult Form(ML.Materia materia)
        {
            if (materia.IdMateria == 0) //add
            {
                BL.Materia.AddLinQ(materia);
            }
            else //update
            {
                BL.Materia.Update(materia);
            }

            return View();
        }


        public ActionResult Delete(int IdMateria)
        {
            ML.Result result = BL.Materia.Delete(IdMateria);
            
            if (result.Correct)
            {
                //modal

                
            }
            return View();
        }


    }
}