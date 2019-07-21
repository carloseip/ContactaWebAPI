using System;
using System.Collections.Generic;

namespace ContactateWebAPI.Models
{
    public partial class InfoLogin
    {
        public int IdInfoLogin { get; set; }
        public string Correo { get; set; }
        public DateTime? InicioSesion { get; set; }
        public DateTime? FinSesion { get; set; }
    }
}
