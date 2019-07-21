using System;
using System.Collections.Generic;

namespace ContactateWebAPI.Models
{
    public partial class Servicios
    {
        public Servicios()
        {
            FacturaServicios = new HashSet<FacturaServicios>();
        }

        public int IdServicios { get; set; }
        public string Descripcion { get; set; }
        public double? Precio { get; set; }
        public bool? Estado { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<FacturaServicios> FacturaServicios { get; set; }
    }
}
