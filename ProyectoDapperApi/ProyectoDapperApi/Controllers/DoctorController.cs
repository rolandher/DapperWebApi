using AutoMapper;
using Entities.Comandos;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using UseCases.PuertaEntrada;

namespace ProyectoDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private readonly IDoctorUseCase _doctorUseCase;
        private readonly IMapper _mapper;


        public DoctorController(IDoctorUseCase doctorUseCase, IMapper mapper)
        {
            _doctorUseCase = doctorUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<Doctor> Agregar_Doctor(IngresarDoctor command)
        {
            return await _doctorUseCase.AgregarDoctor(_mapper.Map<Doctor>(command));
        }

        [HttpGet]
        public async Task<List<Doctor>> Obtener_Listado_Doctor()
        {
            return await _doctorUseCase.ObtenerListaDoctores();
        }

       
        [HttpGet]
        [Route("ObtenerId")]
        public async Task<Doctor> ObtenerIdDoctor(int id)
        {
            return await _doctorUseCase.ObtenerDoctorPorId(id);
        }


    }
}
