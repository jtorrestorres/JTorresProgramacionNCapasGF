using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PL //
{
    internal class Materia
    {
        public static void Add()  //Add materia by LINQ
        {
            //Id ->Autoincrementable

            ML.Materia materia = new ML.Materia();

            Console.WriteLine("Ingrese el Nombre de la materia");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese los créditos de la materia");
            materia.Creditos = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el costo de la materia");
            materia.Costo = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Id del Semestre");

            materia.Semestre = new ML.Semestre();  //inicializando
            materia.Semestre.IdSemestre = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Id del usuario que realizó la operación");
            materia.Usuario = new ML.Usuario();
            materia.Usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la fecha de inscripción dd-MM-yyyy"); //08-06-1996
            materia.FechaInscripcion = Console.ReadLine();

            ML.Result result = BL.Materia.AddEF(materia);

            if (result.Correct)
            {
                Console.WriteLine("La materia fue insertada correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar la materia" + result.ErrorMessage);
            }



        }

        public static void Update()
        {

        }

        public static void Delete()
        {

        }

        public static void GetAll()
        {

            ML.Result result = BL.Materia.GetAll();

            if (result.Correct)
            {
                foreach (ML.Materia materia in result.Objects)
                {
                    Console.WriteLine("IdMateria: " + materia.IdMateria);
                    Console.WriteLine("Nombre: " + materia.Nombre);
                    Console.WriteLine("Creditos: " + materia.Creditos);
                    Console.WriteLine("Costo: " + materia.Costo);
                }
            }
        }

        //short cuts
        public static void GetById()
        {
            Console.WriteLine("Ingrese el Id que desee visualizar");

            ML.Materia materia = new ML.Materia();
            materia.IdMateria = int.Parse(Console.ReadLine());




            ML.Result result = BL.Materia.GetById(materia.IdMateria);


            if (result.Correct)
            {
                materia  = (ML.Materia)result.Object;

                Console.WriteLine("IdMateria: " + materia.IdMateria);
                Console.WriteLine("Nombre: " + materia.Nombre);
                Console.WriteLine("Creditos: " + materia.Creditos);
                Console.WriteLine("Costo: " + materia.Costo);

            }
        }


    }
}
