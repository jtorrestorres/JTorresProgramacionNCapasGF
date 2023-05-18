using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {

        //IdUsuario
        public static void Suma(int a, int b, out int result)
        {
            result = a + b;
        }

        public static int Suma(int a, int b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {

            int suma=0;

            Console.WriteLine(suma);

            Suma(2, 8, out suma);

            Console.WriteLine(suma);

            suma = Suma(2, 8);



            PL.Materia.Add();
           // PL.Materia.GetById();







            //primitivo
            int Edad = 26;
            object x = Edad; //boxing
            int resultado = (int)x; //unboxing


            //complejo
            ML.Materia materia = new ML.Materia();
            object z = materia; //boxing

            ML.Materia materiaResultado = (ML.Materia)z;//unboxing






        }
    }
}
