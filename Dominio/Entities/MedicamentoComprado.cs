using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class MedicamentoComprado : BaseEntity
    {
        public int IdCompraFk { get; set; }
        public Compra Compra { get; set; }
        public int IdMedicamentoFk { get; set; }
        public Medicamento Medicamento { get; set; }
        public int CantidadComprada { get; set; }
        public int PrecioCompra { get; set; }
        public ICollection<Medicamento> Medicamentos { get; set; }
    }
}