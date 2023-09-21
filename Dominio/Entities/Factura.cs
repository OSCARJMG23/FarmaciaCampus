using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Factura : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public int TotalPagar { get; set; }
        public int IdFormaDePagoFk { get; set; }
        public FormaDePago FormaDePago { get; set; }
        public ICollection<MovimientoInventario> MovimientosInventario { get; set; }

    }
}