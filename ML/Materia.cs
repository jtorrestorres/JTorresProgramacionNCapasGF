using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Materia //
    {
        //backend, sololetras, solonúmeros
        //Atributos
        
        public int IdMateria { get; set; }  
        



        [Required(ErrorMessage = "El nombre de la materia es requerido")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se aceptan letras")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        [Required]
        [Range(1,255,ErrorMessage ="Los créditos deben de tener un valor de 1 a 255")]
        public byte Creditos { get; set; }


        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Los créditos deben de tener un valor de 1 a 255")]
        public decimal Costo { get; set; }

        public ML.Semestre Semestre { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaModificacion { get; set; }

        [Display(Name ="Fecha de inscripción")]
        public string FechaInscripcion { get; set; } //fecha nacimiento
        public List<object> Materias { get; set; }
        public ML.Usuario Usuario { get; set; }
        public byte[] Imagen { get; set; }



        //10-06-2022
        //06-10-2022
    }
}
