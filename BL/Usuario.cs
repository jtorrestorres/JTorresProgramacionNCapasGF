using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JTorresProgramacionNCapasEntities context = new DL_EF.JTorresProgramacionNCapasEntities())
                {

                    ObjectParameter IdUsuario = new ObjectParameter("IdUsuario", typeof(int));
                    
                    var resultQuery = context.UsuarioAdd(IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno);

                    context.SaveChanges();

                    if ((int)IdUsuario.Value > 0)
                    {
                        // insert dirección
                        usuario.IdUsuario = (int)IdUsuario.Value;

                        ML.Result resultDireccion = BL.Direccion.Add(usuario);
                        
                        if(resultDireccion.Correct)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = resultDireccion.ErrorMessage;
                        }
                        
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo insertar la materia";
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
