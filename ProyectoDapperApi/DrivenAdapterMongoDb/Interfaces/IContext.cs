using DrivenAdapterMongoDb.EntidadesMongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivenAdapterMongoDb.Interfaces
{
    public interface IContext
    {
        public IMongoCollection<EntidadPaciente> Pacientes { get; }

    }
}
