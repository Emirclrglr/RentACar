using Microsoft.AspNetCore.Mvc;

namespace RentACar.UI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminFooterViewPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
