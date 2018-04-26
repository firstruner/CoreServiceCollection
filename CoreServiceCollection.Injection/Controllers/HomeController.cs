using System.Diagnostics;
using CoreServiceCollection.Core.Services;
using CoreServiceCollection.Injection.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreServiceCollection.Injection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIdentifierServiceScoped _identifierServiceScoped;
        private readonly IIdentifierServiceTransient _identifierServiceTransient;

        public HomeController(IIdentifierServiceScoped identifierServiceScoped, IIdentifierServiceTransient identifierServiceTransient)
        {
            _identifierServiceScoped = identifierServiceScoped;
            _identifierServiceTransient = identifierServiceTransient;
        }

        public IActionResult Index([FromServices] IIdentifierServiceScoped identifierServiceScopedFromMethod, [FromServices] IIdentifierServiceTransient identifierServiceTransientFromMethod)
        {
            ViewData["Message"] = "Voici nos courriels si vous désirez nous contacter !";

            var viewModel = new IndexViewModel
            {
                TransientId = _identifierServiceTransient.Id,
                ScopedId = _identifierServiceScoped.Id,
                OtherTransientId = identifierServiceTransientFromMethod.Id,
                OtherScopedId = identifierServiceScopedFromMethod.Id
            };

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
