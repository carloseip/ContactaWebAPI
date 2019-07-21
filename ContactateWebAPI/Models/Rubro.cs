using System;
using System.Collections.Generic;

namespace ContactateWebAPI.Models
{
    public partial class Rubro
    {
        public Rubro()
        {
            Empresa = new HashSet<Empresa>();
        }

        public int IdRubro { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
