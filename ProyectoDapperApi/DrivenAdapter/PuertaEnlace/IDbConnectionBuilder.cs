using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivenAdapter.PuertaEnlace
{
    public interface IDbConnectionBuilder
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}
