using AutoMapper;
using Entities.Comandos;
using Entities.Entidades;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using UseCases.PuertaEntrada;

namespace ProyectoDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetaMedicaController : ControllerBase
    {

        private readonly IRecetaMedicaUseCase _recetaMedicaUseCase;
        private readonly IMapper _mapper;


        public RecetaMedicaController(IRecetaMedicaUseCase recetaMedicaUseCase, IMapper mapper)
        {
            _recetaMedicaUseCase = recetaMedicaUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<RecetaMedica> Agregar_RecetaMedica(IngresarRecetaMedica command)
        {
            return await _recetaMedicaUseCase.AgregarRecetaMedica(_mapper.Map<RecetaMedica>(command));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<RecetaMedicaPaciente> Obtener_Listado_RecetaMedica(int id)
        {
            return await _recetaMedicaUseCase.ObtenerListaRecetaMedica(id);
        }


    }
}
