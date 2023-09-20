using ApiFarmacia.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace ApiFarmacia.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Compra, CompraDto>().ReverseMap();
        CreateMap<Compra, ComprasDto>().ReverseMap();

        CreateMap<Empleado, EmpleadoDto>().ReverseMap();
        CreateMap<Empleado, EmpleadosDto>().ReverseMap();

        CreateMap<Paciente, PacienteDto>().ReverseMap();
        CreateMap<Paciente, PacientesDto>().ReverseMap();

        CreateMap<Medicamento, MedicamentoDto>().ReverseMap();
        CreateMap<Medicamento, MedicamentosDto>().ReverseMap();
    }
}