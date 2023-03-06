using Microsoft.AspNetCore.Mvc;

namespace FrontToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")] 
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
