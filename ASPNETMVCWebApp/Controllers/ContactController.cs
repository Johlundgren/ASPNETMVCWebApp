using ASPNETMVCWebApp.ViewModels;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace ASPNETMVCWebApp.Controllers;

public class ContactController(IHttpClientFactory clientFactory) : Controller
{
    private readonly IHttpClientFactory _clientFactory = clientFactory;

    public IActionResult ContactIndex()
    {
        SetServiceOptions();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ContactIndex(ContactRequestViewModel viewModel)
    {
        SetServiceOptions();
        if (ModelState.IsValid)
        {
            var client = _clientFactory.CreateClient();

            var json = JsonConvert.SerializeObject(viewModel);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7226/api/Contacts", content);
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Your message has been sent successfully!";
                return RedirectToAction("ContactIndex");
            }
            else
            {
                TempData["ErrorMessage"] = "There was an error sending your message. Please try again.";
            }
        }
        return View();
    }

    private void SetServiceOptions()
    {
        ViewBag.ServiceOptions = new SelectList(new[]
        {
            new { Value = "", Text = "None" },
            new { Value = "Consultation", Text = "Consultation" },
            new { Value = "Support", Text = "Support" },
            new { Value = "Sales", Text = "Sales" },
            new { Value = "Other", Text = "Other" }
        }, "Value", "Text");
    }
}


//Funkar perfekt
//[HttpPost]
//public async Task<IActionResult> ContactIndex(ContactRequestViewModel viewModel)
//{
//    if (ModelState.IsValid)
//    {
//        var client = _clientFactory.CreateClient();

//        var json = JsonConvert.SerializeObject(viewModel);
//        using var content = new StringContent(json, Encoding.UTF8, "application/json");
//        var response = await client.PostAsync("https://localhost:7226/api/Contacts", content);
//        if (response.IsSuccessStatusCode)
//        {
//            ViewData["Success"] = true;
//        }
//    }
//    return View();
//}