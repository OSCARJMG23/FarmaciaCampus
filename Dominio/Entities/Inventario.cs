using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Inventario : BaseEntity
    {
        public int Stock { get; set; }
        public ICollection<Medicamento> Medicamentos { get; set; }
        public ICollection<MovimientoInventario> MovimientosInventario { get; set; }

    }
}