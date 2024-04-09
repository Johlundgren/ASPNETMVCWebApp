using ASPNETMVCWebApp.ViewModels;
using Azure;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace ASPNETMVCWebApp.Controllers;

[Authorize]
public class CourseController(IConfiguration configuration, CategoryService categoryService, CourseService courseService) : Controller
{
    private readonly IConfiguration _configuration = configuration;
    private readonly CategoryService _categoryService = categoryService;
    private readonly CourseService _courseService = courseService;

    public async Task<IActionResult> Courses(string category = "", string searchQuery = "")
    {
        if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
        {
            var viewModel = new CourseViewModel
            {
                Categories = await _categoryService.GetCategoriesAsync(token),
                Courses = await _courseService.GetCoursesAsync(token, category, searchQuery),
            };

            return View(viewModel);
        }
        return View("Unauthorized");
    }

    //public async Task<IActionResult> Details(int id)
    //{
    //    if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
    //    {
    //        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    //        var response = await _http.GetAsync($"https://localhost:7226/api/courses/{id}?key={_configuration["ApiKey:Secret"]}");
    //        if (response.IsSuccessStatusCode)
    //        {
    //            var course = JsonConvert.DeserializeObject<Course>(await response.Content.ReadAsStringAsync());

    //            return View(course);
    //        }
    //    }
    //    return View();
    //}
}

//public async Task<IActionResult> Courses()
//{
//    var viewModel = new CourseViewModel();

//    if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
//    {
//        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

//        var response = await _http.GetAsync($"https://localhost:7226/api/courses?key={_configuration["ApiKey:Secret"]}");
//        if (response.IsSuccessStatusCode)
//        {
//            viewModel = JsonConvert.DeserializeObject<CourseViewModel>(await response.Content.ReadAsStringAsync());

//            if (viewModel != null && viewModel.Succeeded)
//            {
//                return View(viewModel);
//            }
//        }
//    }

//    return View();
//}

//public async Task<IActionResult> Courses(string category = "", string searchQuery = "")
//{
//    var viewModel = new CourseViewModel();

//    if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
//    {
//        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

//        //Url grejer
//        string courseUrl = $"https://localhost:7226/api/courses?key={_configuration["ApiKey:Secret"]}";
//        if (!string.IsNullOrEmpty(category))
//        {
//            courseUrl += $"&category={Uri.EscapeDataString(category)}";
//        }

//        if (!string.IsNullOrEmpty(searchQuery))
//        {
//            courseUrl += $"&searchQuery={Uri.EscapeDataString(searchQuery)}";
//        }

//        // Kurser
//        var courseResponse = await _http.GetAsync(courseUrl);
//        if (courseResponse.IsSuccessStatusCode)
//        {
//            viewModel = JsonConvert.DeserializeObject<CourseViewModel>(await courseResponse.Content.ReadAsStringAsync());
//        }

//        // Kategorier
//        var categoryResponse = await _http.GetAsync($"https://localhost:7226/api/categories?key={_configuration["ApiKey:Secret"]}");
//        if (categoryResponse.IsSuccessStatusCode)
//        {
//            var categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(await categoryResponse.Content.ReadAsStringAsync());
//            viewModel.Categories = categories;
//        }

//        if (viewModel != null && viewModel.Succeeded)
//        {
//            return View(viewModel);
//        }
//    }

//    return View(viewModel);
//}





//public class CourseController(HttpClient http, IConfiguration configuration, CategoryService categoryService, CourseService courseService) : Controller
//{
//    private readonly HttpClient _http = http;
//    private readonly IConfiguration _configuration = configuration;
//    private readonly CategoryService _categoryService = categoryService;
//    private readonly CourseService _courseService = courseService;

//    public async Task<IActionResult> Courses(string category = "", string searchQuery = "")
//    {
//        var viewModel = new CourseViewModel
//        {
//            Categories = await _categoryService.GetCategoriesAsync(),
//            Courses = await _courseService.GetCoursesAsync(),
//        };

//        if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
//        {
//            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

//        }

//        return View(viewModel);
//    }