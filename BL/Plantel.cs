using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Plantel
    {
        public static ML.Result GetAllLinQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JTorresProgramacionNCapasEntities context = new DL_EF.JTorresProgramacionNCapasEntities())
                {
                    var listPlanteles = (from plantelAlias in context.Plantels
                                         select new
                                         {
                                             IdPlantel = plantelAlias.IdPlantel,
                                             Nombre = plantelAlias.Nombre,
                                         }).ToList();

                    if (listPlanteles != null)
                    {

                        if (listPlanteles.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (var obj in listPlanteles)
                            {
                                ML.Plantel plantelItem = new ML.Plantel();
                                plantelItem.IdPlantel = obj.IdPlantel;
                                plantelItem.Nombre = obj.Nombre;

                                result.Objects.Add(plantelItem);
                            }

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "La tabla Materia no tiene registros";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }

    }
}
