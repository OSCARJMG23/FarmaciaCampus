using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Paciente : BaseEntity
    {
        public string Nombre { get; set; }
        public string IdDireccionFk { get; set; }
        public Direccion Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdRecetaFk { get; set; }
        public RecetaMedica RecetaMedica { get; set; }
        public ICollection<MovimientoInventario> MovimientosInventario { get; set; }
    }
}