using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {

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
