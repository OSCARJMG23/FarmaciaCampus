using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Ventas : BaseEntity
    {
        public DateTime FechaVenta { get; set; }
        public int IdPacienteFk { get; set; }
        public Paciente Paciente { get; set; }
        public int IdEmpleadoFk { get; set; }
        public Empleado Empleado { get; set; }
    }
}