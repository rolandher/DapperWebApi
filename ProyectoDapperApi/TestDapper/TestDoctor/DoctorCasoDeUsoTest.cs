using Entities.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.CasosDeUso;
using UseCases.PuertaEntrada.Repositorio;

namespace TestDapper.TestDoctor
{
    public class DoctorCasoDeUsoTest
    {
        [Fact]
        public async Task ObtenerListaDoctores()
        {
            var doctorRepositorioMock = new Mock<IDoctorRepositorio>();

            doctorRepositorioMock.Setup(x => x.ObtenerListaDoctores()).ReturnsAsync(new List<Doctor>());

            var doctorCasoDeUso = new DoctorCasoDeUso(doctorRepositorioMock.Object);

            var result = await doctorCasoDeUso.ObtenerListaDoctores();

            Assert.NotNull(result);
            Assert.IsType<List<Doctor>>(result);

           
        }

        [Fact]

        public async Task AgregarDoctor()
        {
            var doctorRepositorioMock = new Mock<IDoctorRepositorio>();

            doctorRepositorioMock.Setup(x => x.AgregarDoctor(It.IsAny<Doctor>())).ReturnsAsync(new Doctor());

            var doctorCasoDeUso = new DoctorCasoDeUso(doctorRepositorioMock.Object);

            var result = await doctorCasoDeUso.AgregarDoctor(new Doctor());

            Assert.NotNull(result);
            Assert.IsType<Doctor>(result);
        }

    }
}
