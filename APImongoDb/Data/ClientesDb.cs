using APImongoDb.Data.Configuration;
using APImongoDb.Entites;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APImongoDb.Data
{


    public class ClientesDb
    {
        private readonly IMongoCollection<Cliente> _ClientesCollection;


    public  ClientesDb(IClientesStoreDatabaseSettings settings)
    {
            var mdbClient = new MongoClient(settings.ConnectionString);
            var database = mdbClient.GetDatabase(settings.DatabaseName);
            _ClientesCollection = database.GetCollection<Cliente>(settings.ClientesCollectionName);
        }


        public List<Cliente> Get()
        {
            return _ClientesCollection.Find(book => true).ToList();
        }

        public Cliente GetById(string id)
        {
            return _ClientesCollection.Find<Cliente>(cliente => cliente.Id == id).FirstOrDefault();
        }

        public Cliente Create(Cliente book)
        {
            _ClientesCollection.InsertOne(book);
            return book;
        }

        public void Update(string id, Cliente cli)
        {
            _ClientesCollection.ReplaceOne(cliente => cliente.Id == id, cli);
        }

        public void Delete( Cliente cli)
        {
            _ClientesCollection.DeleteOne(cliente => cliente.Id == cli.Id);
        }

        public void DeleteById(string id)
        {
            _ClientesCollection.DeleteOne(cliente => cliente.Id == id);
        }
    }
}
