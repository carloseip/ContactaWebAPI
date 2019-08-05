using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactateWebAPI.Models
{
    public partial class TarjetaPresentacion
    {
        public TarjetaPresentacion()
        {
            Contacto = new HashSet<Contacto>();
        }

        public int IdTarjeta { get; set; }
        public string Ocupacion { get; set; }
        public string Empresa { get; set; }
        public string Especialidad { get; set; }
        public string Imagen { get; set; }
        public int IdUsuario { get; set; }
        public int? IdEmpresa { get; set; }
        public string Telefono { get; set; }
        [MaxLength(50)]
        public string Correo { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Contacto> Contacto { get; set; }
    }
}
