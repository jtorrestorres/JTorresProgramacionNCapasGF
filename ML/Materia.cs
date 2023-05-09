using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia //
    {
        //Atributos
        public int IdMateria { get; set; }
        public string Nombre { get; set; }
        public byte Creditos { get; set; }
        public decimal Costo { get; set; }
        public ML.Semestre Semestre { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaModificacion { get; set; }
        public string FechaInscripcion { get; set; } //fecha nacimiento
        public List<object> Materias { get; set; }
        public ML.Usuario Usuario { get; set; }
        public byte[] Imagen { get; set; }



        //10-06-2022
        //06-10-2022
    }
}
