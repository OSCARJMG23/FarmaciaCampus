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
        public DateTime FechaExpiracion { get; set; }
        public int IdProveedorFk { get; set; }
        public Proveedor Proveedor { get; set; }
        public int IdPresentacionFk { get; set; }
        public Presentacion Presentacion { get; set; }
        public int IdMarcaFk { get; set; }
        public Marca Marca { get; set; }
        public int IdInventarioFk { get; set; }
        public Inventario Inventario { get; set; }

    }
}