using ApiFarmacia.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace ApiFarmacia.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Ciudad, CiudadDto>().ReverseMap();
        CreateMap<Ciudad, CiudadesDto>().ReverseMap();

        CreateMap<Departamento, DepartamentoDto>().ReverseMap();
        CreateMap<Departamento, DepartamentosDto>().ReverseMap();

        CreateMap<Empleado, EmpleadoDto>().ReverseMap();
        CreateMap<Empleado, EmpleadosDto>().ReverseMap();

        CreateMap<Medicamento, MedicamentoDto>().ReverseMap();
        CreateMap<Medicamento, MedicamentosDto>().ReverseMap();

        CreateMap<Paciente, PacienteDto>().ReverseMap();
        CreateMap<Paciente, PacientesDto>().ReverseMap();

        CreateMap<Proveedor, ProveedorDto>().ReverseMap();
        CreateMap<Proveedor, ProveedoresDto>().ReverseMap();
    }
}