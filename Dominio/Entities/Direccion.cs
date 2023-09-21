using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Direccion : BaseEntity
    {
        public string TipoViaPrincipal { get; set; }
        public int NumeroViaPrincipal { get; set; }
        public int NumeroViaSecundaria { get; set; }
        public string Barrio { get; set; }
        public string Complemento { get; set; }
        public int IdCiudadFk { get; set; }
        public Ciudad Ciudad { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }
        public ICollection<Proveedor> Proveedores { get; set; }
    }
}