﻿using Microsoft.AspNetCore.Mvc;

namespace RentACar.UI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminScriptsViewPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
