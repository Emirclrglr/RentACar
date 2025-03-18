using Microsoft.AspNetCore.Mvc;

namespace RentACar.UI.ViewComponents.CarBookingFilterComponents
{
    public class _CarBookingFilterViewPartial:ViewComponent
    {
        public IViewComponentResult Invoke(string v)
        {
            TempData["value"] = v;
            return View();
        }
    }
}
