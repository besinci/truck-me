using Microsoft.AspNetCore.Mvc;

namespace TruckMe.API.Controllers
{
    public class HomeController : BaseController
    {
        public string Index()
        {
            return "hello world";
        }
    }
}
