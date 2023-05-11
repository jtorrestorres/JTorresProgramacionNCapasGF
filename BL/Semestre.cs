using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Semestre
    {
        public static ML.Result GetAllLinQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JTorresProgramacionNCapasEntities context = new DL_EF.JTorresProgramacionNCapasEntities())
                {
                    var listSemestres = (from semestreAlias in context.Semestres
                                        select new
                                        {
                                            IdSemestre = semestreAlias.IdSemestre,
                                            Nombre = semestreAlias.Nombre,                                            
                                        }).ToList();

                    if (listSemestres != null)
                    {

                        if (listSemestres.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (var obj in listSemestres)
                            {
                                ML.Semestre semestreItem = new ML.Semestre();
                                semestreItem.IdSemestre = obj.IdSemestre;
                                semestreItem.Nombre = obj.Nombre;
                                
                                result.Objects.Add(semestreItem);
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
