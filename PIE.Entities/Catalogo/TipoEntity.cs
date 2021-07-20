using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIE.Entities.Catalogo
{
    public class TipoEntity
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public byte Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
