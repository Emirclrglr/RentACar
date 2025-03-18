using Microsoft.AspNetCore.Mvc;

namespace RentACar.UI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminSidebarViewPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
