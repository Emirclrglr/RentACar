using Microsoft.AspNetCore.Mvc;

namespace RentACar.UI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
