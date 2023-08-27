using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nimbus.Model;

namespace Nimbus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private List<NimbusSubscriptions> nimbusSubscriptions = new List<NimbusSubscriptions>
        {
            new NimbusSubscriptions{Id = 1, UserId = "0001", IsValid = true, StartDate = new DateTime(2023, 8, 20), EndDate = new DateTime(2023, 11, 20)},
            new NimbusSubscriptions{Id = 2, UserId = "0002", IsValid = false, StartDate = new DateTime(2023, 4, 12), EndDate = new DateTime(2023, 7, 11)}
        };

        // ... otras acciones ...

        // POST: api/Subscriptions/Pay/{id}
        [HttpPost("Pay/{id}")]
        public IActionResult PayForSubscription(int id)
        {
            var subscription = nimbusSubscriptions.Find(sb => sb.Id == id);

            try
            {
                if (subscription != null && subscription.IsValid)
                {
                    // Simulamos un proceso de pago
                    // Puedes implementar tu logica de pago aqui

                    // Para dar un ejemplo, Asumamos que el pago fue satisfactorio

                    subscription.IsValid = true; //Configuramos la subscripcion como valida despues de recibir el pago exitosamente.
                    return StatusCode(200, "Payment successful. Subscription is now valid.");
                }
                else if (subscription != null && !subscription.IsValid)
                {
                    return StatusCode(400, "Subscription is already invalid.");
                }
                else
                {
                    return StatusCode(404, "Subscription not found.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while processing the payment.");
            }
        }

        // ... Otras acciones ...
    }
}
