using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Compra : BaseEntity
    {
        public DateTime FechaCompra { get; set; }
        public int IdProveedorFk { get; set; }
        public Proveedor Proveedor { get; set; }

        public ICollection<MedicamentoComprado> MedicamentosComprados { get; set; }

    }
}