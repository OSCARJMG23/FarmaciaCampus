namespace Dominio.Entities;

public class Rol : BaseEntity
{
    public string Nombre { get; set; }
    public ICollection<Empleado> Empleados { get; set; } = new HashSet<Empleado>();
}