using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Proveedor : BaseEntity
    {
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public int IdDireccionFk { get; set; }
        public Direccion Direccion { get; set; }
        public ICollection<Medicamento> Medicamentos { get; set; }
        public ICollection<MovimientoInventario> MovimientosInventario { get; set; }
    }
}