using AutoMapper;
using NutrIA.Models;
using NutrIA.Models.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Paciente, PacienteDto>();
        CreateMap<Nutricionista, NutricionistaDto>();
    }
}