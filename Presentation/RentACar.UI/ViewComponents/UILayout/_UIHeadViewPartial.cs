using Microsoft.AspNetCore.Mvc;

namespace RentACar.UI.ViewComponents.HomeLayout
{
    public class _UIHeadViewPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
