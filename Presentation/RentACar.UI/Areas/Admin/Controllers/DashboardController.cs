using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;

namespace RentACar.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
      

        public IActionResult Index()
        {
            return View();
        }
    }
}
