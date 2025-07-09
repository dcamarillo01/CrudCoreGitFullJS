using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int IdUsuario { get; set; } 

    public string? Nombre { get; set; } 
     
    public string? ApellidoPaterno { get; set; }

    public DateOnly? FechaNacimiento { get; set; }
}
