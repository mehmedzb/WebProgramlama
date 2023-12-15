using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevu.Controllers
{
    public class RandevuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
