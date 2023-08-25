using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{

    
        
    [Route("api/[controller]")]
    [ApiController]
    public class NimbussController : ControllerBase
    {
        // GET: api/<Nimbuss>
        [HttpGet]
        public List<Nimbus> Listado()
        {
            var a = new Nimbus();

            return a.listado();
        }


        // GET api/<Nimbuss>/5
        [HttpGet("{id}")]
        public List<Nimbus> Get(int id)
        {
            var a = new Nimbus().listado();

            var listadoID = a.FindAll(x => x.id == id);

            return listadoID;

        }

        // POST api/<Nimbuss>
        [HttpPost]
        public List<Nimbus> Post(int id, string category, double price, string service)
        {
            var listado = new Nimbus().listado();
            Nimbus nimbus = new Nimbus();
            nimbus.id = id;
            nimbus.category = category;
            nimbus.price = price;
            nimbus.service = service;

            listado.Add(nimbus);

            return listado;
        }
        // PUT: api/Category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    
} 

