using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

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
                using(DL_EF.JTorresProgramacionNCapasEntities context = new DL_EF.JTorresProgramacionNCapasEntities())
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
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
             
            return result;

        }
        public static void Update()
        {

        }

        public static void Delete()
        {

        }



        public static void GetById()
        {

        }
    }
}
