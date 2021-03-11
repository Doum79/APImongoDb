using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APImongoDb.Data.Configuration
{
    public class ClientesStoreDatabaseSettings : IClientesStoreDatabaseSettings
    {
        public string ClientesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }

    public interface IClientesStoreDatabaseSettings
    {
        public string ClientesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}

