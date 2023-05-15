using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    //Producto -> Departamento -> Area
    //Alumno -> Grupo -> Plantel
    public class Plantel
    {
        public int IdPlantel { get; set; }
        public string Nombre { get; set; }
        public string URL { get; set; }
        public List<object> Planteles { get; set; }
    }
}
