using AutoMapper;
using Entities.Comandos;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using UseCases.PuertaEntrada;

namespace ProyectoDapperApi.Controllers
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
        public async Task<Paciente> Agregar_Paciente(IngresarPaciente command)
        {
            return await _pacienteUseCase.AgregarPaciente(_mapper.Map<Paciente>(command));
        }

        [HttpGet]
        public async Task<List<Paciente>> Obtener_Listado_Paciente()
        {
            return await _pacienteUseCase.ObtenerListaPacientes();
        }

     
    }
}
