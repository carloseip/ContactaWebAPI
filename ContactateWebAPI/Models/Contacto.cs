using System;
using System.Collections.Generic;

namespace ContactateWebAPI.Models
{
    public partial class Contacto
    {
        public int IdTarjeta { get; set; }
        public int IdUsuario { get; set; }
        public bool? Estado { get; set; }
        public string Evento { get; set; }

        public virtual TarjetaPresentacion IdTarjetaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
