using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class MovimientoInventario : BaseEntity
    {
        public int IdEmpleadoFk { get; set; }
        public Empleado Empleado { get; set; }
        public int IdPacienteFk { get; set; }
        public Paciente Paciente { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int IdTipoMovimientoFk { get; set; }
        public TipoMovimientoInventario TipoMovimientoInventario { get; set; }
        public int IdFacturaFk { get; set; }
        public Factura Factura { get; set; }
        public ICollection<DetalleMovimientoInventario> DetallesMovimientoInventario { get; set; }
    }
}