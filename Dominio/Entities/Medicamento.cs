using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Medicamento : BaseEntity
    {
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public int IdProveedorFk { get; set; }
        public Proveedor Proveedor { get; set; }

        public ICollection<MedicamentoComprado> MedicamentosComprados { get; set; }
        public ICollection<MedicamentoVendido> MedicamentosVendidos { get; set; }
    }
}