using Microsoft.AspNetCore.Mvc;

namespace RentACar.UI.ViewComponents.UIComponents
{
    public class _BecomeADriverViewPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
