using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIE.Entities.Catalogo;

namespace PIE.Entities.Catalogo
{
    public class ProductoEntity
    {
        public long Id { get; set; }
        public string SKU { get; set; }
        public string Fert { get; set; }
        public string NumSerie { get; set; }
        public long Fk_Modelo { get; set; }
        public byte Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public ModeloEntity objModelo { get; set; }
    }
}
