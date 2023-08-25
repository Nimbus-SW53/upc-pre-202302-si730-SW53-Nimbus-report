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
    public class NimbusController : ControllerBase
    {
        //Esta lista es para probar
        private List<NimbusService> nimbusServices = new List<NimbusService>
        {
            new NimbusService { Id = "0001", Nombre = "Servicio 1", Descripcion = "Descripción del servicio 1", Estado = "En proceso" },
            new NimbusService { Id = "0002", Nombre = "Servicio 2", Descripcion = "Descripción del servicio 2", Estado = "Pendiente" }
        };
        private int lastServiceId = 2;

        // GET: api/Nimbus
        [HttpGet]
        public ActionResult<IEnumerable<NimbusService>> GetServices()
        {
            return Ok(nimbusServices);
        }

        // GET: api/Nimbus/{id}
        [HttpGet("{id}")]
        public ActionResult<NimbusService> GetService(string id)
        {
            var service = nimbusServices.Find(s => s.Id == id);
            if (service != null)
            {
                return Ok(service);
            }
            return NotFound($"Error 404:\n \n Servicio con Id {id} no encontrado.");
        }

        // POST: api/Nimbus/CreateService
        [HttpPost("CreateService")]
        public ActionResult<string> CreateService([FromBody] NimbusService nimbusService)
        {
            if (nimbusService == null)
            {
                return BadRequest("Error 404:\n \nLos datos de la orden de servicio son inválidos.");
            }

            nimbusService.Id = (lastServiceId + 1).ToString("D4");
            lastServiceId++;

            nimbusServices.Add(nimbusService);

            return Ok($"Orden de servicio creada con éxito. Id: {nimbusService.Id}");
        }

        // PUT: api/Nimbus/UpdateServiceStatus/{id}
        [HttpPut("UpdateServiceStatus/{id}")]
        public ActionResult<string> UpdateServiceStatus(string id, [FromBody] string status)
        {
            var service = nimbusServices.Find(s => s.Id == id);
            if (service != null)
            {
                service.Estado = status;
                return Ok("Estado del servicio actualizado con éxito.");
            }
            return NotFound($"Error 404:\n \n Servicio con Id {id} no encontrado.");
        }

        // DELETE: api/Nimbus/DeleteService/{id}
        [HttpDelete("DeleteService/{id}")]
        public ActionResult<string> DeleteService(string id)
        {
            var service = nimbusServices.Find(s => s.Id == id);
            if (service != null)
            {
                nimbusServices.Remove(service);
                return Ok("Servicio eliminado con éxito.");
            }
            return NotFound($"Error 404:\n \n Servicio con Id {id} no encontrado.");
        }
    }
}