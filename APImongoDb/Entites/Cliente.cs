using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APImongoDb.Entites
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string nombre { get; set; }
        public string Appel { get; set; }
        public int Edad { get; set; }
        public ICollection<Telefono> Telefonos { get; set; }
        [BsonElement("Direction")]
         public Direction DirectionCliente { get; set; }
    }
}
