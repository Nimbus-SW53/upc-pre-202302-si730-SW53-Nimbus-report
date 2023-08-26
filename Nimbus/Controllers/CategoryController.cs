using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nimbus.Model;

namespace Nimbus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private List<NimbusService> nimbusServices = new List<NimbusService>
        {
            new NimbusService { Id = "0001", Nombre = "Servicio 1", Descripcion = "Descripción del servicio 1", Estado = "En proceso" },
            new NimbusService { Id = "0002", Nombre = "Servicio 2", Descripcion = "Descripción del servicio 2", Estado = "Pendiente" }
        };
        private int lastServiceId = 2;

        // GET: api/Category/ListServices
        [HttpGet("ListServices")]
        public ActionResult<IEnumerable<NimbusService>> ListServices()
        {
            return Ok(nimbusServices);
        }

        // GET: api/Category/{id}
        [HttpGet("{id}")]
        public ActionResult<NimbusService> GetService(string id)
        {
            var service = nimbusServices.Find(s => s.Id == id);
            if (service != null)
            {
                return Ok(service);
            }
            return NotFound($"Servicio con Id {id} no encontrado.");
        }

        // POST: api/Category/CreateService
        [HttpPost("CreateService")]
        public ActionResult<string> CreateService([FromBody] NimbusService nimbusService)
        {
            if (nimbusService == null)
            {
                return BadRequest("Los datos de la orden de servicio son inválidos.");
            }

            nimbusService.Id = (lastServiceId + 1).ToString("D4");
            lastServiceId++;

            nimbusServices.Add(nimbusService);

            return Ok($"Orden de servicio creada con éxito. Id: {nimbusService.Id}");
        }

        // PUT: api/Category/UpdateServiceStatus/{id}
        [HttpPut("UpdateServiceStatus/{id}")]
        public ActionResult<string> UpdateServiceStatus(string id, [FromBody] string status)
        {
            var service = nimbusServices.Find(s => s.Id == id);
            if (service != null)
            {
                service.Estado = status;
                return Ok("Estado del servicio actualizado con éxito.");
            }
            return NotFound($"Servicio con Id {id} no encontrado.");
        }

        // PUT: api/Category/UpdateServiceDescription/{id}
        [HttpPut("UpdateServiceDescription/{id}")]
        public ActionResult<string> UpdateServiceDescription(string id, [FromBody] string description)
        {
            var service = nimbusServices.Find(s => s.Id == id);
            if (service != null)
            {
                service.Descripcion = description;
                return Ok("Descripción del servicio actualizada con éxito.");
            }
            return NotFound($"Servicio con Id {id} no encontrado.");
        }

        // PUT: api/Category/UpdateServiceName/{id}
        [HttpPut("UpdateServiceName/{id}")]
        public ActionResult<string> UpdateServiceName(string id, [FromBody] string newName)
        {
            var service = nimbusServices.Find(s => s.Id == id);
            if (service != null)
            {
                service.Nombre = newName;
                return Ok($"Nombre del servicio actualizado a: {newName}");
            }
            return NotFound($"Servicio con Id {id} no encontrado.");
        }

        // DELETE: api/Category/DeleteService/{id}
        [HttpDelete("DeleteService/{id}")]
        public ActionResult<string> DeleteService(string id)
        {
            var service = nimbusServices.Find(s => s.Id == id);
            if (service != null)
            {
                nimbusServices.Remove(service);
                return Ok("Servicio eliminado con éxito.");
            }
            return NotFound($"Servicio con Id {id} no encontrado.");
        }
    }
}
