using Entities.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.CasosDeUso;
using UseCases.PuertaEntrada.Repositorio;

namespace TestDapper.TestPaciente
{
    public class PacienteCasoDeUsoTest
    {
      
        [Fact]
        public async Task ObtenerListaPacientes()
        {
           
            var pacienteRepositorioMock = new Mock<IPacienteRepositorio>();

            pacienteRepositorioMock.Setup(x => x.ObtenerListaPacientes()).ReturnsAsync(new List<Paciente>());
            var pacienteCasoDeUso = new PacienteCasoDeUso(pacienteRepositorioMock.Object);
            var result = await pacienteCasoDeUso.ObtenerListaPacientes();
            Assert.NotNull(result);
            Assert.IsType<List<Paciente>>(result);             

        }

        [Fact]
        public async Task AgregarPaciente()
        {

            var pacienteRepositorioMock = new Mock<IPacienteRepositorio>();

            pacienteRepositorioMock.Setup(x => x.AgregarPaciente(It.IsAny<Paciente>())).ReturnsAsync(new Paciente());
            var pacienteCasoDeUso = new PacienteCasoDeUso(pacienteRepositorioMock.Object);
            var result = await pacienteCasoDeUso.AgregarPaciente(new Paciente());
            Assert.NotNull(result);
            Assert.IsType<Paciente>(result);
        }

        [Fact]
        public async Task ObtenerPacientePorId()
        {

            var pacienteRepositorioMock = new Mock<IPacienteRepositorio>();

            pacienteRepositorioMock.Setup(x => x.ObtenerPacientePorId(It.IsAny<int>())).ReturnsAsync(new Paciente());
            var pacienteCasoDeUso = new PacienteCasoDeUso(pacienteRepositorioMock.Object);
            var result = await pacienteCasoDeUso.ObtenerPacientePorId(1);
            Assert.NotNull(result);
            Assert.IsType<Paciente>(result);
        }



    }
}
           
