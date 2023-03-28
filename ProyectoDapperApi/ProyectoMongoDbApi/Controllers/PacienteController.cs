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

        [HttpPost]
        public async Task<Paciente> Registrar_Paciente([FromBody] IngresarPaciente command)
        {
            return await _pacienteUseCase.AgregarPaciente(_mapper.Map<Paciente>(command));
        }

        [HttpGet]
        public async Task<List<Paciente>> ObtenerPacientes()
        {
            return await _pacienteUseCase.ObtenerListaPacientes();
        }

        [HttpGet("{id}")]
        public async Task<Paciente> ObtenerPacientePorId(string id)
        {
            return await _pacienteUseCase.ObtenerPacientePorId(id);
        }

        [HttpPut]
        public async Task<Paciente> ActualizarPaciente([FromBody] Paciente command)
        {
            return await _pacienteUseCase.ActualizarPaciente(command);
        }        
        
    } 
    
}
