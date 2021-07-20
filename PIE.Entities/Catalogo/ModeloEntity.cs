using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIE.Entities.Catalogo;

namespace PIE.Entities.Catalogo
{
    public class ModeloEntity
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public long Fk_IdTipo { get; set; }
        public byte Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public TipoEntity objTipo { get; set; }
    }
}
