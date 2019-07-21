using System;
using System.Collections.Generic;

namespace ContactateWebAPI.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Servicios = new HashSet<Servicios>();
        }

        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Servicios> Servicios { get; set; }
    }
}
