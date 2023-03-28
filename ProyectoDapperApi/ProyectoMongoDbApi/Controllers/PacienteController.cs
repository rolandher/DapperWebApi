using AutoMapper;
using Entities.Comandos;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UseCases.PuertaEntrada;

namespace ProyectoMongoDbApi.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class PacienteController : ControllerBase
        {
            private readonly IPacienteUseCase _pacienteUseCase;
            private readonly IMapper _mapper;

            public PacienteController(IPacienteUseCase pacienteUseCase, IMapper mapper)
            {
                _pacienteUseCase = pacienteUseCase;
                _mapper = mapper;
            }

            [HttpGet]
            public async Task<List<Paciente>> ObtenerPacientes()
            {
                return await _pacienteUseCase.ObtenerListaPacientes();
            }

            [HttpPost]
            public async Task<Paciente> Registrar_Paciente([FromBody] IngresarPaciente command)
            {
                return await _pacienteUseCase.AgregarPaciente(_mapper.Map<Paciente>(command));
            }
        }
    
}
