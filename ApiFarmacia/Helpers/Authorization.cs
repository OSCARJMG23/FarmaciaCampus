namespace ApiFarmacia.Helpers;

public class Authorization
{
    public enum Roles
    {
        Administrador,
        Empleado
    }

    public const Roles rol_default = Roles.Administrador;
}