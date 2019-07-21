using System;
using System.Collections.Generic;

namespace ContactateWebAPI.Models
{
    public partial class FacturaServicios
    {
        public int IdFactura { get; set; }
        public int IdServicios { get; set; }
        public double? Cantidad { get; set; }
        public DateTime? FechaVencimiento { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
        public virtual Servicios IdServiciosNavigation { get; set; }
    }
}
