using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.Grupo = new ML.Grupo();
            alumno.Grupo.Plantel = new ML.Plantel();
            //BL 
            ML.Result resultPlanteles = BL.Plantel.GetAllLinQ();
            if (resultPlanteles.Correct)
            {
                alumno.Grupo.Plantel.Planteles = resultPlanteles.Objects; //todos los planteles 
            }
            

            return View(alumno);
        }

        public JsonResult GetGrupo(int IdPlantel)
        {
            //BL- > Grupos de determinado plantel 
            ML.Result resultGrupos = BL.Grupo.GetByIdPlantelLinQ(IdPlantel);
            //crear un nuevo stored GrupoGetByIdPlantel -> DepartamentoGetByIdArea
            return Json(resultGrupos.Objects);
        }
    }
}