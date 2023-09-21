using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class DetalleMovimientoInventario : BaseEntity
    {
        public int IdMovimientoInventarioFk { get; set; }
        public MovimientoInventario MovimientoInventario { get; set; }
        public int IdInventarioFk { get; set; }
        public Inventario Inventario { get; set; }
    }
}