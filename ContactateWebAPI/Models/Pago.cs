using System;
using System.Collections.Generic;

namespace ContactateWebAPI.Models
{
    public partial class Pago
    {
        public int IdPago { get; set; }
        public int IdFactura { get; set; }
        public string Descripcion { get; set; }
        public string MesVencimiento { get; set; }
        public string AñoVencimiento { get; set; }
        public string CodigoSeguridad { get; set; }
        public string NumeroTarjeta { get; set; }
        public int IdTipoPago { get; set; }
        public string Documento { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
        public virtual TipoPago IdTipoPagoNavigation { get; set; }
    }
}
