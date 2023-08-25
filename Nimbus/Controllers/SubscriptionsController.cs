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
    
    public class SubscriptionsController: ControllerBase
    {
         private List<NimbusSubscriptions> nimbusSubscriptions = new List<NimbusSubscriptions>
        {
            new NimbusSubscriptions{Id = 1, UserId = "0001", IsValid = true, StartDate = new DateTime(2023,8,20),EndDate = new DateTime(2023,11,20)},
            new NimbusSubscriptions{Id = 2, UserId = "0002", IsValid = false, StartDate = new DateTime(2023,4,12),EndDate = new DateTime(2023,7,11)}
        };
            
        
        // GET: api/Subscriptions
        [HttpGet]
        public ActionResult<IEnumerable<NimbusSubscriptions>> GetServices()
        {
            return StatusCode(200);
        }

        // GET: api/Subscriptions/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<NimbusSubscriptions> GetService(int id)
        {
            var suscription = nimbusSubscriptions.Find(sb => sb.Id == id);
            
            try
            {
                if (suscription != null)
                {
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(404); 
                }
            }
            catch (Exception e)
            {
                return StatusCode(500); 
            }
        }

        // POST: api/Subscriptions
        [HttpPost]
        public IActionResult  Post([FromBody] NimbusSubscriptions newSubscription)
        {
            newSubscription = new NimbusSubscriptions();
            newSubscription.IsValid = true;
            
            try
            {
                if (newSubscription.IsValid)
                {
                    return StatusCode(201); 
                }
                else
                {
                    return StatusCode(400); 
                }
            }
            catch (Exception e)
            {
                return StatusCode(500); 
            }
        }

        // PUT: api/Subscriptions/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] bool IsValid)
        {
            var suscription = nimbusSubscriptions.Find(sb => sb.Id == id);
            
            try
            {
                if (suscription != null)
                {
                    suscription.IsValid = IsValid;
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(404); 
                }
            }
            catch (Exception e)
            {
                return StatusCode(500); 
            }
        }

        // DELETE: api/Subscriptions/5
        [HttpDelete("{id}")]
        public  IActionResult Delete(int id)
        {
            var suscription = nimbusSubscriptions.Find(sb => sb.Id == id);
            
            try
            {
                if (suscription != null)
                {
                    nimbusSubscriptions.Remove(suscription);
                    return StatusCode(204);
                }
                else
                {
                    return StatusCode(404); 
                }
            }
            catch (Exception e)
            {
                return StatusCode(500); 
            }
        }
    }
}

