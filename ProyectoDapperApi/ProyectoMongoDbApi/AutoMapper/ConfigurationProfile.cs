using AutoMapper;
using DrivenAdapterMongoDb.EntidadesMongo;
using Entities.Comandos;
using Entities.Entities;
using System.IO;

namespace ProyectoMongoDbApi.AutoMapper
{
    public class ConfigurationProfile : Profile
    {

        public ConfigurationProfile()
        {
            CreateMap<IngresarPaciente, Paciente>().ReverseMap();
            CreateMap<EntidadPaciente, Paciente>().ReverseMap();
        }
    }
}
