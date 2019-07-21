using System;
using System.Collections.Generic;

namespace ContactateWebAPI.Models
{
    public partial class Acceso
    {
        public int IdAcceso { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
    }
}
