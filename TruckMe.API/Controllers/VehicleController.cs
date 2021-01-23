using Microsoft.AspNetCore.Mvc;

namespace TruckMe.API.Controllers
{
    public class VehicleController : BaseController
    {
        [HttpGet]
        public IActionResult List()
        {
            // get vehicles
            return Ok();
        }
    }
}