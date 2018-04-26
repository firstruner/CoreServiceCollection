using System.Diagnostics;
using CoreServiceCollection.Caching.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreServiceCollection.Caching.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Voici nos courriels si vous désirez nous contacter !";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
