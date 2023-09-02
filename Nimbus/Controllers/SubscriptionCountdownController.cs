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
        // GET: api/Subscriptions/RemainingDays/{id}
        [HttpGet("RemainingDays/{id}")]
        public IActionResult GetRemainingDays(int id)
        {
            var subscription = nimbusSubscriptions.Find(sb => sb.Id == id);

            try
            {
                if (subscription != null)
                {
                    if (subscription.IsValid)
                    {
                        // Calcula los días restantes hasta que venza la suscripción
                        var today = DateTime.Today;
                        var daysRemaining = (subscription.EndDate - today).Days;

                        return StatusCode(200, $"Días restantes hasta que la suscripción finalice: {daysRemaining}");
                    }
                    else
                    {
                        return StatusCode(400, "La suscripción ya ha sido invalidada anteriormente.");
                    }
                }
                else
                {
                    return StatusCode(404, "Suscripción no encontrada.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocurrió un error mientras se calcularon los días de suscripción restantes d este mes.");
            }
        }
    }
