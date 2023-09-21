namespace ApiFarmacia.Helpers;

public class Authorization
{
    public enum Roles
    {
        Administrator,
        Manager,
        Employee
    }

    public const Roles rol_default = Roles.Administrator;
}