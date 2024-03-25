using ASPNETMVCWebApp.Models.Sections;
using ASPNETMVCWebApp.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETMVCWebApp.Controllers
{
    public class DefaultController(HttpClient httpClient) : Controller
    {
        private readonly HttpClient _httpClient = httpClient;

        [Route("/")]
        public IActionResult Home()
        {
            var viewModel = new HomeIndexViewModel();
            ViewData["Title"] = viewModel.Title;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync("https://localhost:7226/api/subscribers", content);

                    if (response.IsSuccessStatusCode)
                    {
                        ViewData["Status"] = "Success";
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        ViewData["Status"] = "Already Exists";
                    }
                }
                catch
                {
                    ViewData["Status"] = "ConnectionFailed";
                }
            }
            else
            {
                ViewData["Status"] = "Invalid";
            }
            return View(viewModel);
        }

        [Route("/error")]
        public IActionResult Error404(int statusCode) => View();
    }
}