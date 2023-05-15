using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Grupo
    {
        public static ML.Result GetByIdPlantelLinQ(int IdPlantel)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JTorresProgramacionNCapasEntities context = new DL_EF.JTorresProgramacionNCapasEntities())
                {
                    var listGrupos = (from grupoAlias in context.Grupoes
                                         where grupoAlias.IdPlantel ==  IdPlantel
                                         select new
                                         {
                                             IdGrupo = grupoAlias.IdGrupo,
                                             Nombre = grupoAlias.Nombre,
                                         }).ToList();

                    if (listGrupos != null)
                    {

                        if (listGrupos.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (var obj in listGrupos)
                            {
                                ML.Grupo grupoItem = new ML.Grupo();
                                grupoItem.IdGrupo = obj.IdGrupo;
                                grupoItem.Nombre = obj.Nombre;

                                result.Objects.Add(grupoItem);
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
