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
            materia.Materias = new List<object>();

            ML.Result result = BL.Materia.GetAllLinQ();

            if (result.Correct)
            {
                //materia.Materias = result.Objects;
            }
            

            return View(materia);
        }

        [HttpGet] // Mostrar el formulario
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            
            ML.Result resultSemestres =BL.Semestre.GetAllLinQ();
            materia.Semestre = new ML.Semestre();
            materia.Semestre.Semestres = resultSemestres.Objects;

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
                ML.Result result = BL.Materia.AddLinQ(materia);

                if (result.Correct)
                {
                    //mediante el viewbag enviamos datos
                    //del controlador -> hacia la vista
                    ViewBag.Mensaje = "Se ha ingresado correctamente la materia";
                }
                else
                {
                    ViewBag.Mensaje = "No se ha ingresado correctamente la materia. Error: " + result.ErrorMessage;
                }

            }
            else //update
            {
                ML.Result result = BL.Materia.Update(materia);

                if (result.Correct)
                {
                    //mediante el viewbag enviamos datos
                    //del controlador -> hacia la vista
                    ViewBag.Mensaje = "Se ha actualizado correctamente la materia";
                }
                else
                {
                    ViewBag.Mensaje = "No se ha podido actualizar correctamente la materia. Error: " + result.ErrorMessage;
                }
            }

            return PartialView("Modal");
        }


        public ActionResult Delete(int IdMateria)
        {
            ML.Result result = BL.Materia.Delete(IdMateria);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Se ha eliminado correctamente la materia";
            }
            else
            {
                ViewBag.Mensaje = "No se ha podido eliminar la materia. Error: " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }


    }
}