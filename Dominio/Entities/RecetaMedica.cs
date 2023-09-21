using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class RecetaMedica : BaseEntity
    {
        public string MedicoRemitente { get; set; }
        public string Descripcion { get; set; }
        public int IdDireccionFk { get; set; }
        public Direccion Direccion { get; set; }
    }
}