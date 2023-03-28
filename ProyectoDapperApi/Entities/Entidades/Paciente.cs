using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Paciente

    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Sexo { get; set; }      

        public Paciente() { }

        public static void Validar(Paciente paciente)
        {
            if (paciente.Nombre == null)
            {
                throw new ArgumentNullException("El nombre es requerido.");
            }
            if (paciente.Fecha_Nacimiento == null)
            {
                throw new ArgumentNullException("La fecha de nacimiento es requerida.");
            }
            if (paciente.Sexo == null)
            {
                throw new ArgumentNullException("El sexo es requerido.");
            }


        }
    }
}
