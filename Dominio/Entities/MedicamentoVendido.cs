using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class MedicamentoVendido : BaseEntity
    {
        public int IdVentaFk { get; set; }
        public Venta Venta { get; set; }
        public int IdMedicamentoFk { get; set; }
        public Medicamento Medicamento { get; set; }
        public int CantidadVendida { get; set; }
        public int Precio { get; set; }
    }
}