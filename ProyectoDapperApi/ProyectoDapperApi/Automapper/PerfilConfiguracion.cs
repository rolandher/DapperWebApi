﻿using AutoMapper;
using Entities.Comandos;
using Entities.Entities;


namespace ProyectoDapperApi.Automapper
{
    public class PerfilConfiguracion : Profile
    {
        public PerfilConfiguracion()
        {
            CreateMap<IngresarPaciente, Paciente>().ReverseMap();
            CreateMap<IngresarDoctor, Doctor>().ReverseMap();
            CreateMap<IngresarRecetaMedica, RecetaMedica>().ReverseMap();            
        }
    }
}
