using Microsoft.AspNetCore.Mvc;

namespace ASPNETMVCWebApp.Controllers;

public class ContactController : Controller
{
    public IActionResult ContactIndex()
    {
        return View();
    }
}
