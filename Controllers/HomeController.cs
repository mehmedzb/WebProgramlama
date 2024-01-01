using HastaneWeb.Models;
using HastaneWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HastaneWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LanguageService _localization;

        public HomeController(ILogger<HomeController> logger , LanguageService localization)
        {
            _logger = logger;
            _localization = localization;
        }

        public IActionResult Index()
        {
            ViewBag.Welcome = _localization.GetKey("Welcome").Value;
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            return View();
        }

        // change language with cookie
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(
                               CookieRequestCultureProvider.DefaultCookieName,
                               CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                               new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                               );
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}