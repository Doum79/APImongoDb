using APImongoDb.Data;
using APImongoDb.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APImongoDb.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly ClientesDb _clientesdb;

        public ClientesController(ClientesDb clientesDb)
        {
            _clientesdb = clientesDb;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clientesdb.Get());
        }

        [HttpGet("{id:length(24)}", Name = "GetCliente")]

        public IActionResult Get(string id)
        {
            var cliente = _clientesdb.GetById(id);
            if(cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }


        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            _clientesdb.Create(cliente);
            return CreatedAtRoute("GetCliente", new
            {
                id = cliente.Id.ToString()
            },
              cliente  ) ;
        }


        [HttpPut("{id:length(24)}")]

        public IActionResult Update(string id, Cliente cli)
        {
            var cliente = _clientesdb.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _clientesdb.Update(id, cli);
            return NoContent();
        }

        [HttpGet("{id:length(24)}")]

        public IActionResult DeleteById(string id)
        {
            var cliente = _clientesdb.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _clientesdb.DeleteById(cliente.Id);
            return NoContent();
        }
    }
}
