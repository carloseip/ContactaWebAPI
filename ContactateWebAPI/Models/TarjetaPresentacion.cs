using System;
using System.Collections.Generic;

namespace ContactateWebAPI.Models
{
    public partial class TarjetaPresentacion
    {
        public int IdTarjeta { get; set; }
        public string Ocupación { get; set; }
        public string Empresa { get; set; }
        public string Especialidad { get; set; }
        public string Imagen { get; set; }
        public int IdUsuario { get; set; }
        public int? IdEmpresa { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
