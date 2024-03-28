using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASPNETMVCWebApp.Controllers;

[Route("/courses")]
public class CourseController : Controller
{
    public async Task<IActionResult> Courses()
    {
        using var http = new HttpClient();
        var response = await http.GetAsync("https://localhost:7226/api/courses");
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<IEnumerable<CourseEntity>>(json);

        return View(data);
    }
}
