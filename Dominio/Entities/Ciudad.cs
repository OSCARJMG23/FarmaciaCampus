using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Ciudad
    {
        public string Nombre { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<Direccion> Direcciones { get; set; }
    }
}