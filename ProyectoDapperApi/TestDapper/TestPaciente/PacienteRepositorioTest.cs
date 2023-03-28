using DrivenAdapter.Repositorios;
using Entities.Entities;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.PuertaEntrada.Repositorio;

namespace TestDapper.TestPaciente
{
    public class PacienteRepositorioTest
    {
        private readonly Mock<IPacienteRepositorio> _mockPacienteRepositorio;
        public PacienteRepositorioTest()
        {
            _mockPacienteRepositorio = new();
        }

        [Test]
        public async Task AgregarPacienteAsync()
        {
            //// Arrange
            //var paciente = new Paciente
            //{
            //    Nombre = "Juan",
            //    Fecha_Nacimiento = DateTime.Now,
            //    Sexo = "M",
            //};

            //_mockPacienteRepositorio.Setup(x => x.AgregarPaciente(paciente)).ReturnsAsync(paciente);

            //// Act
            //var pacienteRepositorio = new PacienteRepositorio();
            //var result = await pacienteRepositorio.AgregarPaciente(paciente);

            //// Assert

            //Assert.NotNull(result);
            //Assert.IsType<Paciente>(result);
            //Assert.AreEqual(paciente.Nombre, result.Nombre);
            //Assert.AreEqual(paciente.FechaNacimiento, result.FechaNacimiento);
            //Assert.AreEqual(paciente.Sexo, result.Sexo);

        }

    }


}
