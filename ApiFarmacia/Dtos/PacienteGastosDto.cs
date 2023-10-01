using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFarmacia.Dtos
{
    public class PacienteGastosDto
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public int TotalGastado { get; set; }
    }
}