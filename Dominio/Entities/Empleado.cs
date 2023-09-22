using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Empleado : BaseEntity
    {
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public string Password { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int IdRolFk { get; set; }
        public Rol Rol { get; set; }
        public ICollection<MovimientoInventario> MovimientosInventarios { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
        public ICollection<Rol> Rols { get; set; } = new HashSet<Rol>();
    }
}