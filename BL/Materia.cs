using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Xml;

namespace BL
{
    public class Materia //
    {

        //    if (row[4].ToString() != "") //"1"
        //                                {
        //                                    materia.Semestre.IdSemestre = byte.Parse(row[4].ToString());
        //}
        //                                else
        //                                {
        //                                    materia.Semestre.IdSemestre = 0;
        //                                }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "MateriaGetAll";

                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tableMateria = new DataTable();

                            da.Fill(tableMateria);

                            result.Objects = new List<object>(); //inicializarlo

                            if (tableMateria.Rows.Count > 0)
                            {
                                foreach (DataRow row in tableMateria.Rows)
                                {
                                    ML.Materia materia = new ML.Materia();
                                    materia.IdMateria = int.Parse(row[0].ToString());

                                    materia.Nombre = row[1].ToString();
                                    materia.Creditos = byte.Parse(row[2].ToString());
                                    materia.Costo = decimal.Parse(row[3].ToString());
                                    materia.Semestre = new ML.Semestre();  //operador ternario
                                    materia.Semestre.IdSemestre = (row[4].ToString() != "") ? byte.Parse(row[4].ToString()) : byte.Parse("0"); // 

                                    materia.FechaCreacion = row[5].ToString();
                                    materia.FechaModificacion = row[6].ToString();


                                    materia.Usuario = new ML.Usuario();  //operador ternario
                                    materia.Usuario.IdUsuario = (row[7].ToString() != "") ? int.Parse(row[7].ToString()) : int.Parse("0"); // 

                                    materia.Imagen = Encoding.ASCII.GetBytes(row[8].ToString());
                                    result.Objects.Add(materia);
                                }
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "La tabla materia no tiene registros";
                            }


                            result.Correct = true;
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

        public static ML.Result GetById(int IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "MateriaGetById";

                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdMateria", IdMateria);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tableMateria = new DataTable();

                            da.Fill(tableMateria);

                            if (tableMateria.Rows.Count > 0)
                            {
                                DataRow row = tableMateria.Rows[0];

                                ML.Materia materia = new ML.Materia();
                                materia.IdMateria = int.Parse(row[0].ToString());

                                materia.Nombre = row[1].ToString();
                                materia.Creditos = byte.Parse(row[2].ToString());
                                materia.Costo = decimal.Parse(row[3].ToString());

                                result.Object = materia;//Boxing

                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "La tabla materia no tiene registros";
                            }


                            result.Correct = true;
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

        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "MateriaAdd";

                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Nombre", materia.Nombre);
                        cmd.Parameters.AddWithValue("@Creditos", materia.Creditos);
                        cmd.Parameters.AddWithValue("@Costo", materia.Costo);
                        cmd.Parameters.AddWithValue("@IdSemestre", materia.Semestre.IdSemestre);
                        cmd.Parameters.AddWithValue("@IdUsuarioModificacion", materia.Usuario.IdUsuario);
                        cmd.Parameters.Add("@Imagen", System.Data.SqlDbType.VarBinary).Value = DBNull.Value;


                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo registrar el usuario";
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

        public static ML.Result AddEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JTorresProgramacionNCapasEntities context = new DL_EF.JTorresProgramacionNCapasEntities())
                {

                    //string -> DateTime

                    DateTime fechaInscripcion = DateTime.ParseExact(materia.FechaInscripcion, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                    var resultQuery = context.MateriaAdd(materia.Nombre, materia.Creditos, materia.Costo, materia.Semestre.IdSemestre, materia.Usuario.IdUsuario, materia.Imagen, fechaInscripcion);

                    context.SaveChanges();

                    if (resultQuery > 0)
                    {
                        result.Correct = true;
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
        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            return result;

        }

        public static ML.Result Delete(int IdMateria)
        {
            ML.Result result = new ML.Result();
            return result;
        }
        public static void GetById()
        {

        }


        public static ML.Result AddLinQ(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JTorresProgramacionNCapasEntities context = new DL_EF.JTorresProgramacionNCapasEntities())
                {
                    DL_EF.Materia materiaLinq = new DL_EF.Materia();
                    materiaLinq.Nombre = materia.Nombre;
                    materiaLinq.Creditos = materia.Creditos;
                    materiaLinq.Costo = materia.Costo;
                  //materiaLinq.IdSemestre = materia.Semestre.IdSemestre;
                  //  materiaLinq.IdUsuarioModificacion = materia.Usuario.IdUsuario;
                    materiaLinq.FechaCreacion = DateTime.Now;
                    materiaLinq.FechaModificacion = DateTime.Now;
                    materiaLinq.FechaInscripcion = DateTime.ParseExact(materia.FechaInscripcion, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                    context.Materias.Add(materiaLinq);

                    int rowsAffected = context.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al insertar la materia";
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

        public static ML.Result GetAllLinQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JTorresProgramacionNCapasEntities context = new DL_EF.JTorresProgramacionNCapasEntities())
                {
                    var listMaterias = (from materiaAlias in context.Materias
                                        select new
                                        {
                                            IdMateria1 = materiaAlias.IdMateria,
                                            Nombre1 = materiaAlias.Nombre,
                                            Creditos1 = materiaAlias.Creditos,
                                            Costo1 = materiaAlias.Costo

                                        }).ToList();



                    if (listMaterias != null)
                    {

                        if (listMaterias.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (var obj in listMaterias)
                            {
                                ML.Materia materiaItem = new ML.Materia();
                                materiaItem.IdMateria = obj.IdMateria1;
                                materiaItem.Nombre = obj.Nombre1;
                                materiaItem.Creditos = obj.Creditos1.Value;
                                materiaItem.Costo = obj.Costo1.Value;

                                result.Objects.Add(materiaItem);
                            }

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "La tabla Materia no tiene registros";
                        }
                    }

                    //if (rowsAffected > 0)
                    //{
                    //    result.Correct = true;
                    //}
                    //else
                    //{
                    //    result.Correct = false;
                    //    result.ErrorMessage = "Error al insertar la materia";
                    //}
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }


        public static ML.Result GetByLinQ(int IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JTorresProgramacionNCapasEntities context = new DL_EF.JTorresProgramacionNCapasEntities())
                {
                    var itemMateria = (from materiaAlias in context.Materias
                                       where materiaAlias.IdMateria == IdMateria
                                       select new
                                       {
                                           IdMateria1 = materiaAlias.IdMateria,
                                           Nombre1 = materiaAlias.Nombre,
                                           Creditos1 = materiaAlias.Creditos,
                                           Costo1 = materiaAlias.Costo

                                       }).FirstOrDefault();



                    if (itemMateria != null)
                    {
                        ML.Materia materiaItem = new ML.Materia();
                        materiaItem.IdMateria = itemMateria.IdMateria1;
                        materiaItem.Nombre = itemMateria.Nombre1;
                        materiaItem.Creditos = itemMateria.Creditos1.Value;
                        materiaItem.Costo = itemMateria.Costo1.Value;
                        result.Object = materiaItem;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La tabla Materia no tiene registros";
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
