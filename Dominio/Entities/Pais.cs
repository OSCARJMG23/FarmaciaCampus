using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Pais
    {
        public string Nombre { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}