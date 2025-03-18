using Microsoft.AspNetCore.Mvc;

namespace RentACar.UI.ViewComponents
{
    public class _UIScriptViewPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
