using Microsoft.AspNetCore.Mvc;

namespace RentACar.UI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
