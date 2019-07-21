using System;
using System.Collections.Generic;

namespace ContactateWebAPI.Models
{
    public partial class TipoPago
    {
        public TipoPago()
        {
            Pago = new HashSet<Pago>();
        }

        public int IdTipoPago { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Pago> Pago { get; set; }
    }
}
