using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Presentacion : BaseEntity
    {
        public string Nombre { get; set; }
        public ICollection<Medicamento> Medicamentos { get; set; }
    }
}