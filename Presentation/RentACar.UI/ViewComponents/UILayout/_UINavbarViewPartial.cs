using Microsoft.AspNetCore.Mvc;

namespace RentACar.UI.ViewComponents.HomeLayout
{
    public class _UINavbarViewPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
