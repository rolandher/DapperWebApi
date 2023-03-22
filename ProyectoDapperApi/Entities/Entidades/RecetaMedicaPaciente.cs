using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    public class RecetaMedicaPaciente
    {
        public int Id { get; set; }
        public string Nombre_Medicina { get; set; }

        public string Cantidad { get; set; }

        public Doctor Doctor { get; set; }      

        public Paciente Paciente { get; set; }
        
    }
}
