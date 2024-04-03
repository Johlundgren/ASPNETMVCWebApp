using Azure;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace ASPNETMVCWebApp.Controllers;

[Authorize]
public class CourseController(HttpClient http, IConfiguration configuration) : Controller
{
    private readonly HttpClient _http = http;
    private readonly IConfiguration _configuration = configuration;

    public async Task<IActionResult> Courses()
    {

        if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _http.GetAsync($"https://localhost:7226/api/courses?key={_configuration["ApiKey:Secret"]}");
            if (response.IsSuccessStatusCode)
            {
                var courses = JsonConvert.DeserializeObject<IEnumerable<CourseEntity>>(await response.Content.ReadAsStringAsync());
               
                return View(courses);
            }
        }

        return View();
    }

    public async Task<IActionResult> Details(int id)
    {
        if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _http.GetAsync($"https://localhost:7226/api/courses/{id}?key={_configuration["ApiKey:Secret"]}");
            if (response.IsSuccessStatusCode)
            {
                var course = JsonConvert.DeserializeObject<CourseEntity>(await response.Content.ReadAsStringAsync());

                return View(course);
            }
        }
        return View();
    }
}