using Microsoft.AspNetCore.Mvc;

namespace RentACar.UI.ViewComponents
{
    public class _UILoaderViewPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
