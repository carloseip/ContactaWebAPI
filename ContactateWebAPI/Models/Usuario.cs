using System;
using System.Collections.Generic;

namespace ContactateWebAPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            TarjetaPresentacion = new HashSet<TarjetaPresentacion>();
        }

        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int IdRol { get; set; }
        public int IdSexo { get; set; }
        public int IdCodigoPostal { get; set; }

        public virtual CodigoPostal IdCodigoPostalNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
        public virtual Sexo IdSexoNavigation { get; set; }
        public virtual ICollection<TarjetaPresentacion> TarjetaPresentacion { get; set; }
    }
}
