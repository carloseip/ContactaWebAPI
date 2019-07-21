using System;
using System.Collections.Generic;

namespace ContactateWebAPI.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Factura = new HashSet<Factura>();
            TarjetaPresentacion = new HashSet<TarjetaPresentacion>();
        }

        public int IdEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }
        public string Telefono { get; set; }
        public string Logo { get; set; }
        public int IdRubro { get; set; }
        public string RepresentanteLegal { get; set; }
        public string Direccion { get; set; }
        public int IdCodigoPostal { get; set; }

        public virtual CodigoPostal IdCodigoPostalNavigation { get; set; }
        public virtual Rubro IdRubroNavigation { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
        public virtual ICollection<TarjetaPresentacion> TarjetaPresentacion { get; set; }
    }
}
