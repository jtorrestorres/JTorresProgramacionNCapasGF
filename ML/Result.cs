using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Result
    {
        public bool Correct { get; set; } // sí  o no
        public string ErrorMessage { get; set; }  //mensaje de error
        public object Object { get; set; }//get by id
        public List<object> Objects { get; set; } // get all
        public Exception Ex { get; set; }
    }
}
