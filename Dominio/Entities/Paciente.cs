namespace Dominio.Entities;

public class Paciente : BaseEntity
{
    public string Nombre { get; set; }
    public string IdDireccionFk { get; set; }
    public Direccion Direccion { get; set; }
    public string Telefono { get; set; }
    public ICollection<RecetaMedica> Recetas { get; set; }
    public ICollection<MovimientoInventario> MovimientosInventario { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
}
