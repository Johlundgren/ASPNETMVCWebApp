using Microsoft.AspNetCore.Mvc;

namespace ASPNETMVCWebApp.Controllers
{
    public class DefaultController : Controller
    {
        [Route("/")]
        public IActionResult Home() => View();


        [Route("/error")]
        public IActionResult Error404(int statusCode) => View();
    }
}
