using ASPNETMVCWebApp.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETMVCWebApp.Controllers
{
    public class DefaultController : Controller
    {
        [Route("/")]
        public IActionResult Home()
        {
            var viewModel = new HomeIndexViewModel();
            ViewData["Title"] = viewModel.Title;
            return View(viewModel);
        }


        [Route("/error")]
        public IActionResult Error404(int statusCode) => View();
    }
}
