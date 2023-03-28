using DrivenAdapterMongoDb.EntidadesMongo;
using DrivenAdapterMongoDb.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivenAdapterMongoDb
{
    public class Context : IContext
    {
        private readonly IMongoDatabase _database;

        public Context(string stringConnection, string DBname)
        {
            MongoClient cliente = new MongoClient(stringConnection);
            _database = cliente.GetDatabase(DBname);
        }

        public IMongoCollection<EntidadPaciente> Pacientes => _database.GetCollection<EntidadPaciente>("pacientes");
    }
}
