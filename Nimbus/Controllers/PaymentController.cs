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

        // ... other actions ...

        // POST: api/Subscriptions/Pay/{id}
        [HttpPost("Pay/{id}")]
        public IActionResult PayForSubscription(int id)
        {
            var subscription = nimbusSubscriptions.Find(sb => sb.Id == id);

            try
            {
                if (subscription != null && subscription.IsValid)
                {
                    // Simulate a payment process
                    // You can implement your actual payment logic here

                    // For the sake of example, let's assume the payment was successful
                    subscription.IsValid = true; // Set subscription as valid after successful payment
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

        // ... other actions ...
    }
}
