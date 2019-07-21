using System;
using System.Collections.Generic;

namespace ContactateWebAPI.Models
{
    public partial class Factura
    {
        public Factura()
        {
            FacturaServicios = new HashSet<FacturaServicios>();
            Pago = new HashSet<Pago>();
        }

        public int IdFactura { get; set; }
        public string CodigoFactura { get; set; }
        public double? PrecioTotal { get; set; }
        public int IdEmpresa { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<FacturaServicios> FacturaServicios { get; set; }
        public virtual ICollection<Pago> Pago { get; set; }
    }
}
