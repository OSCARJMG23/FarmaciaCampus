using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class FormaDePago : BaseEntity
    {
        public string Nombre { get; set; }
        public ICollection<Factura> Facturas { get; set; }
    }
}