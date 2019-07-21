using System;
using System.Collections.Generic;

namespace ContactateWebAPI.Models
{
    public partial class CodigoPostal
    {
        public CodigoPostal()
        {
            Empresa = new HashSet<Empresa>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdCodigoPostal { get; set; }
        public string NumeroCodigo { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
