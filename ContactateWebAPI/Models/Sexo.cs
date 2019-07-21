using System;
using System.Collections.Generic;

namespace ContactateWebAPI.Models
{
    public partial class Sexo
    {
        public Sexo()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdSexo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
