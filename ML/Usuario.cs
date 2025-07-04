using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ML
{
    public class Usuario
    {

        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public List<object> Usuarios { get; set; }
    }
}
